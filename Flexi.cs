using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum Rate
{
    time,
    speed,
}

public class Flexi : MonoBehaviour
{

    // Initialization
    private static bool _initialized;
    
    // Delegates
    public delegate T Operation<T>(T a, T b, float t);
    public delegate float Distance<T>(T a, T b);

    // Interpolation Instances
    private static Dictionary<int, Coroutine> _routines;
    private static HashSet<int> _pausedRoutines;
    private static int _currentId;

    // Singleton
    private static Flexi _instance;

    public static void Init()
    {
        if (_instance)
            return;
        _routines = new Dictionary<int, Coroutine>();
        _pausedRoutines = new HashSet<int>();
        _currentId = 0;
        GameObject instance = new GameObject("Flexi");
        _instance = instance.AddComponent<Flexi>().GetComponent<Flexi>();
    }

    #region Interpolations
    public static int InterpolateGeneric<T, Q>(Q target, string property, Operation<T> op, Distance<T> dist, 
                                               FlexiKeyFrame<T>[] keyframes)
    {
        if (!_initialized)
            Init();

        PropertyInfo info = typeof(Q).GetProperty(property);

        if (info == null)
            throw new MissingMemberException($"Property '{property}' could not be found in Type {typeof(Q)}");
        if (info.GetValue(target).GetType() != typeof(T))
            throw new InvalidCastException($"Provided property type does not match expected type");

        _currentId++;
        
        Coroutine routine = _instance.StartCoroutine(_instance.Interpolate(target, info, op, dist, keyframes, _currentId));
        _routines.Add(_currentId, routine);
        return _currentId;
    }

    public static int InterpolateInt<T>(T target, string property, FlexiKeyFrame<int>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.IntOp, FlexiOperations.IntDist, keyframes);
    }

    public static int InterpolateInt<T>(T target, string property, int initial, int final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.IntOp, FlexiOperations.IntDist,
                                  FlexiKeyFrame<int>.CreatePair(initial, final, time, curve, rate, events));
    }

    public static int InterpolateFloat<T>(T target, string property, FlexiKeyFrame<float>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.FloatOp, FlexiOperations.FloatDist, keyframes);
    }

    public static int InterpolateFloat<T>(T target, string property, float initial, float final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.FloatOp, FlexiOperations.FloatDist,
                                  FlexiKeyFrame<float>.CreatePair(initial, final, time, curve, rate, events));
    }

    public static int InterpolateVector2<T>(T target, string property, FlexiKeyFrame<Vector2>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector2Op, FlexiOperations.Vector2Dist, keyframes);
    }

    public static int InterpolateVector2<T>(T target, string property, Vector2 initial, Vector2 final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector2Op, FlexiOperations.Vector2Dist,
                                  FlexiKeyFrame<Vector2>.CreatePair(initial, final, time, curve, rate, events));
    }

    public static int InterpolateVector3<T>(T target, string property, FlexiKeyFrame<Vector3>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector3Op, FlexiOperations.Vector3Dist, keyframes);
    }

    public static int InterpolateVector3<T>(T target, string property, Vector3 initial, Vector3 final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector3Op, FlexiOperations.Vector3Dist,
                                  FlexiKeyFrame<Vector3>.CreatePair(initial, final, time, curve, rate, events));
    }

    public static int InterpolateVector4<T>(T target, string property, FlexiKeyFrame<Vector4>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector4Op, FlexiOperations.Vector4Dist, keyframes);
    }

    public static int InterpolateVector4<T>(T target, string property, Vector4 initial, Vector4 final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector4Op, FlexiOperations.Vector4Dist,
                                  FlexiKeyFrame<Vector4>.CreatePair(initial, final, time, curve, rate, events));
    }

    public static int InterpolateQuaternion<T>(T target, string property, FlexiKeyFrame<Quaternion>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.QuaternionOp, FlexiOperations.QuaternionDist, keyframes);
    }

    public static int InterpolateQuaternion<T>(T target, string property, Quaternion initial, Quaternion final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.QuaternionOp, FlexiOperations.QuaternionDist,
                                  FlexiKeyFrame<Quaternion>.CreatePair(initial, final, time, curve, rate, events));
    }

    public static int InterpolateColor<T>(T target, string property, FlexiKeyFrame<Color>[] keyframes)
    {
        return InterpolateGeneric(target, property, FlexiOperations.ColorOp, FlexiOperations.ColorDist, keyframes);
    }

    public static int InterpolateColor<T>(T target, string property, Color initial, Color final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.ColorOp, FlexiOperations.ColorDist,
                                  FlexiKeyFrame<Color>.CreatePair(initial, final, time, curve, rate, events));
    }
    #endregion

    #region Routines
    public static bool Exists(int id)
    {
        if (!_initialized)
            Init();

        return _routines.ContainsKey(id);
    }

    public static bool Paused(int id)
    {
        if (!_initialized)
            Init();

        return _pausedRoutines.Contains(id);
    }

    public static void Pause(int id)
    {
        if (!_initialized)
            Init();

        if (Exists(id))
        {
            if (!Paused(id))
                _pausedRoutines.Add(id);
            else
                Debug.LogWarning($"Interpolation with ID {id} is already paused");
        }
        else
            throw new KeyNotFoundException($"Interpolation with ID {id} does not exist");
    }

    public static void Resume(int id)
    {
        if (!_initialized)
            Init();

        if (Exists(id))
        {
            if (Paused(id))
                _pausedRoutines.Remove(id);
            else
                throw new KeyNotFoundException($"Interpolation with ID {id} is already active");
        }
        else
            throw new KeyNotFoundException($"Interpolation with ID {id} does not exist");
    }

    public static void Cancel(int id)
    {
        if (!_initialized)
            Init();

        if (Exists(id))
        {
            _instance.StopCoroutine(_routines[id]);
            _routines.Remove(id);

            if (Paused(id))
                _pausedRoutines.Remove(id);
        }
        else
            throw new KeyNotFoundException($"Interpolation with ID {id} does not exist");
    }
    #endregion

    private IEnumerator Interpolate<T, Q>(Q target, PropertyInfo info, Operation<T> operation, Distance<T> distance, 
                                          FlexiKeyFrame<T>[] keyframes, int id)
    {
        for (int i = 0; i < keyframes.Length - 1; i++)
        {
            FlexiKeyFrame<T> initialKeyFrame = keyframes[i];
            FlexiKeyFrame<T> finalKeyFrame = keyframes[i + 1];

            T initial = initialKeyFrame.Value;
            T final = finalKeyFrame.Value;
            T current;

            AnimationCurve curve = initialKeyFrame.Curve;

            float time = initialKeyFrame.TimeToNextKeyFrame;
            if (initialKeyFrame.Rate == Rate.speed)
                time = Mathf.Abs(distance(initial, final)) / time;

            FlexiEvent[] events = initialKeyFrame.Events;

            for (float t = 0; t < 1; t += Time.deltaTime/time)
            {
                if (_pausedRoutines.Contains(id))
                {
                    t -= Time.deltaTime / time;
                    yield return null;
                    continue;
                }

                foreach (FlexiEvent flexiEvent in events)
                    flexiEvent.Invoke(t);

                current = operation(initial, final, curve.Evaluate(t));
                info.SetValue(target, current);
                yield return null;
            }

            foreach (FlexiEvent flexiEvent in events)
                flexiEvent.Invoke(1f);
            
            current = operation(initial, final, curve.Evaluate(1));
            info.SetValue(target, current);
        }

        _routines.Remove(id);
        _pausedRoutines.Remove(id);
    }
}
