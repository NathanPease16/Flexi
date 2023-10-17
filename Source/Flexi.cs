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

/// <summary>
/// Handles the starting, stopping, and pausing of interpolations
/// </summary>
public class Flexi : MonoBehaviour
{   
    // Delegates
    public delegate T Interpolate<T>(T a, T b, float t);
    public delegate float Distance<T>(T a, T b);

    // Interpolation Instances
    private static Dictionary<int, Coroutine> _routines;
    private static HashSet<int> _pausedRoutines;
    private static int _currentId;

    // Singleton
    private static Flexi _instance;

    private static void Init()
    {
        if (_instance != null)
            return;

        _pausedRoutines = new HashSet<int>();
        _routines = new Dictionary<int, Coroutine>();

        GameObject instance = new GameObject("Flexi");
        DontDestroyOnLoad(instance);
        _instance = instance.AddComponent<Flexi>().GetComponent<Flexi>();
    }

    #region Interpolations
    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="op">The operation used to calculate linear interpolation at a point t</param>
    /// <param name="dist">Method used to calculate distance between two objects of the same type</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The data type to interpolate</typeparam>
    /// <typeparam name="Q">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateGeneric<T, I>(T target, string property, Interpolate<I> op, Distance<I> dist, 
                                               FlexiKeyFrame<I>[] keyFrames)
    {
        // Initialize the Flexi GameObject if not already one
        if (_instance == null)
            Init();

        // Make sure nothing is null
        if (target == null || property == null || op == null || dist == null || keyFrames == null)
            throw new NullReferenceException("One or more of the following cannot be null: 'target', 'property', 'op', " + 
                                             "'dist', 'keyFrames'");

        // Create the PropertyInfo object to modify the property on target
        PropertyInfo info = typeof(T).GetProperty(property);

        // Make sure info is not null
        if (info == null)
            throw new MissingMemberException($"Property '{property}' could not be found in type '{typeof(T)}'");
        // Make sure types match up between the type of property and the type of T
        if (info.GetValue(target).GetType() != typeof(I))
            throw new InvalidCastException($"Provided property's type '{info.GetValue(target).GetType()}' does not match" + 
                                           $" expected type '{typeof(I)}'");

        _currentId++;
        
        // Start the new coroutine interpolation
        Coroutine routine = _instance.StartCoroutine(_instance.Interpolation(target, info, op, dist, keyFrames, _currentId));
        _routines.Add(_currentId, routine);
        return _currentId;
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateInt<T>(T target, string property, FlexiKeyFrame<int>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.IntOp, FlexiOperations.IntDist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateInt<T>(T target, string property, int initial, int final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.IntOp, FlexiOperations.IntDist,
                                  FlexiKeyFrame<int>.CreatePair(initial, final, time, curve, rate, events));
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateFloat<T>(T target, string property, FlexiKeyFrame<float>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.FloatOp, FlexiOperations.FloatDist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateFloat<T>(T target, string property, float initial, float final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.FloatOp, FlexiOperations.FloatDist,
                                  FlexiKeyFrame<float>.CreatePair(initial, final, time, curve, rate, events));
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateVector2<T>(T target, string property, FlexiKeyFrame<Vector2>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector2Op, FlexiOperations.Vector2Dist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateVector2<T>(T target, string property, Vector2 initial, Vector2 final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector2Op, FlexiOperations.Vector2Dist,
                                  FlexiKeyFrame<Vector2>.CreatePair(initial, final, time, curve, rate, events));
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateVector3<T>(T target, string property, FlexiKeyFrame<Vector3>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector3Op, FlexiOperations.Vector3Dist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateVector3<T>(T target, string property, Vector3 initial, Vector3 final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector3Op, FlexiOperations.Vector3Dist,
                                  FlexiKeyFrame<Vector3>.CreatePair(initial, final, time, curve, rate, events));
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateVector4<T>(T target, string property, FlexiKeyFrame<Vector4>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector4Op, FlexiOperations.Vector4Dist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateVector4<T>(T target, string property, Vector4 initial, Vector4 final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.Vector4Op, FlexiOperations.Vector4Dist,
                                  FlexiKeyFrame<Vector4>.CreatePair(initial, final, time, curve, rate, events));
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateQuaternion<T>(T target, string property, FlexiKeyFrame<Quaternion>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.QuaternionOp, FlexiOperations.QuaternionDist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateQuaternion<T>(T target, string property, Quaternion initial, Quaternion final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.QuaternionOp, FlexiOperations.QuaternionDist,
                                  FlexiKeyFrame<Quaternion>.CreatePair(initial, final, time, curve, rate, events));
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="keyFrames">The key frames to interpolate between</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateColor<T>(T target, string property, FlexiKeyFrame<Color>[] keyFrames)
    {
        return InterpolateGeneric(target, property, FlexiOperations.ColorOp, FlexiOperations.ColorDist, keyFrames);
    }

    /// <summary>
    /// Interpolates between all of the key frames, applying the changes each frame to property on target
    /// </summary>
    /// <param name="target">The object to search for property on</param>
    /// <param name="property">The property on target to modify</param>
    /// <param name="initial">The initial value of the interpolaiton</param>
    /// <param name="final">The final value of the interpolation</param>
    /// <param name="time">The length of the interpolation</param>
    /// <param name="curve">The movement curve for the interpolation</param>
    /// <param name="rate">The movement type of the interpolation</param>
    /// <param name="events">Events to be invoked during the interpolation</param>
    /// <typeparam name="T">The type of target</typeparam>
    /// <returns>The ID of the interpolation</returns>
    public static int InterpolateColor<T>(T target, string property, Color initial, Color final, float time,
                                          AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return InterpolateGeneric(target, property, FlexiOperations.ColorOp, FlexiOperations.ColorDist,
                                  FlexiKeyFrame<Color>.CreatePair(initial, final, time, curve, rate, events));
    }
    #endregion

    #region Routines
    /// <summary>
    /// Searches through all interpolations that have been started and not yet ended, and determines whether or not an interpolation with the given ID exists or not
    /// </summary>
    /// <param name="id">The ID of the interpolation to check</param>
    /// <returns>true if the interpolation exists, false if it does not</returns>
    public static bool Exists(int id)
    {
        if (_instance == null)
            Init();

        return _routines.ContainsKey(id);
    }

    /// <summary>
    /// Searches through all interpolations that have been paused and determines if the interpolation with the given ID is currently paused
    /// </summary>
    /// <param name="id">The ID of the interpolation to check</param>
    /// <returns>true if the interpolation is paused, false if it is not</returns>
    public static bool Paused(int id)
    {
        if (_instance == null)
            Init();

        return _pausedRoutines.Contains(id);
    }

    /// <summary>
    /// Searches for the interpolation with the given ID and pauses it if it is not already paused
    /// </summary>
    /// <param name="id">The ID of the interpolation to pause</param>
    public static void Pause(int id)
    {
        if (_instance == null)
            Init();

        if (Exists(id))
        {
            if (!Paused(id))
                _pausedRoutines.Add(id);
            else
                Debug.LogWarning($"Interpolation with ID {id} is already paused");
        }
        else
            Debug.LogWarning($"Interpolation with ID {id} does not exist");
    }

    /// <summary>
    /// Unpauses the interpolation with the given ID if it is not already unpaused
    /// </summary>
    /// <param name="id">The ID of the interpolation to resume</param>
    public static void Resume(int id)
    {
        if (_instance == null)
            Init();

        if (Exists(id))
        {
            if (Paused(id))
                _pausedRoutines.Remove(id);
            else
                Debug.LogWarning($"Interpolation with ID {id} is already active");
        }
        else
            Debug.LogWarning($"Interpolation with ID {id} does not exist");
    }

    /// <summary>
    /// Cancels the interpolation with the given ID
    /// </summary>
    /// <param name="id">The ID of the interpolation to cancel</param>
    public static void Cancel(int id)
    {
        if (_instance == null)
            Init();

        if (Exists(id))
        {
            _instance.StopCoroutine(_routines[id]);
            _routines.Remove(id);

            if (Paused(id))
                _pausedRoutines.Remove(id);
        }
        else
            Debug.LogWarning($"Interpolation with ID {id} does not exist");
    }
    #endregion

    private IEnumerator Interpolation<T, I>(T target, PropertyInfo info, Interpolate<I> operation, Distance<I> distance, 
                                          FlexiKeyFrame<I>[] keyFrames, int id)
    {
        // Loop through each key frame except for last
        for (int i = 0; i < keyFrames.Length - 1; i++)
        {
            // Get current and next key frame
            FlexiKeyFrame<I> initialKeyFrame = keyFrames[i];
            FlexiKeyFrame<I> finalKeyFrame = keyFrames[i + 1];

            // Make sure neither are null
            if (initialKeyFrame == null || finalKeyFrame == null)
                throw new NullReferenceException("Key frame cannot be null");

            // Get their values
            I initial = initialKeyFrame.Value;
            I final = finalKeyFrame.Value;
            I current;

            AnimationCurve curve = initialKeyFrame.Curve;

            float time = initialKeyFrame.TimeToNextKeyFrame;

            // Convert to speed if needed using distance method
            if (initialKeyFrame.Rate == Rate.speed)
                time = Mathf.Abs(distance(initial, final)) / time;

            FlexiEvent[] events = initialKeyFrame.Events;

            // Go through the interpolation itself
            for (float t = 0; t < 1; t += Time.deltaTime/time)
            {
                // Check to make sure target isn't null every frame (i.e. object was destroyed during interpolation)
                if (target == null)
                {
                    foreach (FlexiEvent flexiEvent in events)
                        flexiEvent.Uninvoke();

                    Debug.LogWarning("'target' became null during interpolation");

                    Cancel(id);
                }

                // If paused, don't increase t and continue on without doing anything
                if (_pausedRoutines.Contains(id))
                {
                    t -= Time.deltaTime / time;
                    yield return null;
                    continue;
                }

                // Try to invoke all the events
                foreach (FlexiEvent flexiEvent in events)
                    flexiEvent.Invoke(t);

                // Assign the property
                current = operation(initial, final, curve.Evaluate(t));
                info.SetValue(target, current);
                yield return null;
            }

            // Ensure everything is at exactly 1, and that every event is uninvoked
            foreach (FlexiEvent flexiEvent in events)
            {
                flexiEvent.Invoke(1f);
                flexiEvent.Uninvoke();
            }

            foreach (FlexiEvent flexiEvent in finalKeyFrame.Events)
            {
                flexiEvent.Invoke(0);
                flexiEvent.Uninvoke();
            }
            
            current = operation(initial, final, curve.Evaluate(1));
            info.SetValue(target, current);
        }

        _routines.Remove(id);
        if (Paused(id))
            _pausedRoutines.Remove(id);
    }
}
