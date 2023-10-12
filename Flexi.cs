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

    #region Keyframes
    private static Keyframe[] linearKeys = new Keyframe[] { new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1) };
    private static Keyframe[] quadraticKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 2, 0) };
    private static Keyframe[] cubicKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 3, 0) };
    private static Keyframe[] bouncingKeys = new Keyframe[] { new Keyframe(0, 0, 0, -1.5f), new Keyframe(1, 1, -1.5f, 0) };
    private static Keyframe[] overshootKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, -1.5f, 0) };
    private static Keyframe[] recoveryKeys = new Keyframe[] { new Keyframe(0, 0, 0, -1.5f), new Keyframe(1, 1, 0, 0) };
    private static Keyframe[] easeInKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 1, 0, .25f, 0) };
    private static Keyframe[] easeOutKeys = new Keyframe[] { new Keyframe(0, 0, 0, 1, 0, .25f), new Keyframe(1, 1, 0, 0) };
    private static Keyframe[] easeInOutKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 0, 0) };
    #endregion

    #region Curves
    public static readonly AnimationCurve linear = new AnimationCurve(linearKeys);
    public static readonly AnimationCurve quadratic = new AnimationCurve(quadraticKeys);
    public static readonly AnimationCurve cubic = new AnimationCurve(cubicKeys);
    public static readonly AnimationCurve bouncing = new AnimationCurve(bouncingKeys);
    public static readonly AnimationCurve overshoot = new AnimationCurve(overshootKeys);
    public static readonly AnimationCurve recovery = new AnimationCurve(recoveryKeys);
    public static readonly AnimationCurve easeIn = new AnimationCurve(easeInKeys);
    public static readonly AnimationCurve easeOut = new AnimationCurve(easeOutKeys);
    public static readonly AnimationCurve easeInOut = new AnimationCurve(easeInOutKeys);
    #endregion

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

    #region Operators
    private static int IntOp(int a, int b, float t)
    {
        return (int)Mathf.LerpUnclamped(a, b, t);
    }

    private static float FloatOp(float a, float b, float t)
    {
        return Mathf.LerpUnclamped(a, b, t);
    }

    private static Vector2 Vector2Op(Vector2 a, Vector2 b, float t)
    {
        return new Vector2
        (
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t)
        );
    }

    private static Vector3 Vector3Op(Vector3 a, Vector3 b, float t)
    {
        return new Vector3
        (
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t),
            Mathf.LerpUnclamped(a.z, b.z, t)
        );
    }

    private static Vector4 Vector4Op(Vector4 a, Vector4 b, float t)
    {
        return new Vector4
        (
            Mathf.LerpUnclamped(a.w, b.w, t),
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t),
            Mathf.LerpUnclamped(a.z, b.z, t)
        );
    }

    private static Quaternion QuaternionOp(Quaternion a, Quaternion b, float t)
    {
        Vector3 opEuler = Vector3Op(a.eulerAngles, b.eulerAngles, t);

        return Quaternion.Euler(opEuler.x, opEuler.y, opEuler.z);
    }

    private static Color ColorOp(Color a, Color b, float t)
    {
        return new Color
        (
            Mathf.LerpUnclamped(a.r, b.r, t),
            Mathf.LerpUnclamped(a.g, b.g, t),
            Mathf.LerpUnclamped(a.b, b.b, t),
            Mathf.LerpUnclamped(a.a, b.a, t)
        );
    }
    #endregion

    #region Distance Formulas
    private static float IntDist(int a, int b)
    {
        return a - b;
    }

    private static float FloatDist(float a, float b)
    {
        return a - b;
    }

    private static float Vector2Dist(Vector2 a, Vector2 b)
    {
        return Vector2.Distance(a, b);
    }


    private static float Vector3Dist(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    private static float Vector4Dist(Vector4 a, Vector4 b)
    {
        return Vector4.Distance(a, b);
    }

    private static float QuaternionDist(Quaternion a, Quaternion b)
    {
        return Vector3.Distance(a.eulerAngles, b.eulerAngles);
    }

    private static float ColorDist(Color a, Color b)
    {
        Vector4 i = new Vector4(a.r, a.g, a.b, a.a);
        Vector4 f = new Vector4(b.r, b.g, b.b, b.a);

        return Vector4.Distance(i, f);
    }
    #endregion

    #region Interpolations
    public static int InterpolateGeneric<T, Q>(Q target, string property, Operation<T> operation, Distance<T> distance, 
                                               T initial, T final, float time, AnimationCurve curve, Rate rate, 
                                               FlexiEvent[] events)
    {
        if (!_initialized)
            Init();

        PropertyInfo info = typeof(Q).GetProperty(property);

        if (info == null)
            throw new MissingMemberException($"Property '{property}' could not be found in Type {typeof(Q)}");
        if (info.GetValue(target).GetType() != typeof(T))
            throw new InvalidCastException($"Provided property type does not match expected type");

        if (curve == null)
            curve = linear;

        if (rate == Rate.speed)
            time = Mathf.Abs(distance(initial, final)) / time;

        if (events == null)
            events = new FlexiEvent[0];

        _currentId++;
        
        Coroutine routine = _instance.StartCoroutine(_instance.Interpolate(target, info, operation, initial, 
                                                                           final, time, curve, events, _currentId - 1));
        _routines.Add(_currentId - 1, routine);
        return _currentId - 1;
    }

    public static int InterpolateInt<T>(T target, string property, int initial, int final, float time, 
                                           AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, IntOp, IntDist, initial, final, time, curve, rate, events);
    }
    
    public static int InterpolateFloat<T>(T target, string property, float initial, float final, float time, 
                                           AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FloatOp, FloatDist, initial, final, time, curve, rate, events);
    }

    public static int InterpolateVector2<T>(T target, string property, Vector2 initial, Vector2 final, float time,
                                             AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, Vector2Op, Vector2Dist, initial, final, time, curve, rate, events);
    }

    public static int InterpolateVector3<T>(T target, string property, Vector3 initial, Vector3 final, float time,
                                             AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, Vector3Op, Vector3Dist, initial, final, time, curve, rate, events);
    }

    public static int InterpolateVector4<T>(T target, string property, Vector4 initial, Vector4 final, float time,
                                             AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, Vector4Op, Vector4Dist, initial, final, time, curve, rate, events);
    }

    public static int InterpolateQuaternion<T>(T target, string property, Quaternion initial, Quaternion final, float time,
                                             AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, QuaternionOp, QuaternionDist, initial, final, time, curve, rate, events);
    }

    public static int InterpolateColor<T>(T target, string property, Color initial, Color final, float time,
                                             AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, ColorOp, ColorDist, initial, final, time, curve, rate, events);
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

    private IEnumerator Interpolate<T, Q>(Q target, PropertyInfo info, Operation<T> operation, T initial, T final, float time,
                                          AnimationCurve curve, FlexiEvent[] events, int id)
    {
        T current;

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

        _routines.Remove(id);
        _pausedRoutines.Remove(id);
    }
}
