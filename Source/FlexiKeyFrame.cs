using System;
using UnityEngine;

[Serializable]
public class FlexiKeyFrame<T>
{
    [SerializeField] private T _value;
    [SerializeField] private float _timeToNextKeyFrame;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Rate _rate;
    [SerializeField] private FlexiEvent[] _events;

    public T Value { get { return _value; } }
    public float TimeToNextKeyFrame { get { return _timeToNextKeyFrame; } }
    public AnimationCurve Curve { get { return _curve; } }
    public Rate Rate { get { return _rate; } }
    public FlexiEvent[] Events { get { return _events; } }

    /// <summary>
    /// Creates a new FlexiKeyFrame object
    /// </summary>
    /// <param name="value">The value of the key frame</param>
    /// <param name="timeToNextKeyFrame">The time to interpolate between this key frame and the next key frame</param>
    /// <param name="curve">The movement curve for this key frame</param>
    /// <param name="rate">The rate mode for this key frame</param>
    /// <param name="events">All events to be called during this key frame</param>
    public FlexiKeyFrame(T value, float timeToNextKeyFrame=0f, AnimationCurve curve=null, Rate rate=Rate.time, 
                         FlexiEvent[] events=null)
    {
        if (value == null)
            throw new NullReferenceException("'value' cannot be null");
        if (timeToNextKeyFrame < 0)
            throw new ArgumentException("'timeToNextKeyFrame' cannot be less than 0");
            
        _value = value;
        _timeToNextKeyFrame = timeToNextKeyFrame;
        _rate = rate;
        _curve = curve;
        _events = events;

        if (_curve == null)
            _curve = FlexiCurves.linear;
        if (_events == null)
            _events = new FlexiEvent[0];
    }

    /// <summary>
    /// Creates a pair of key frames as an array using the given data as the values for the key frames
    /// </summary>
    /// <param name="initial">The value of the first key frame</param>
    /// <param name="final">The value of the second key frame</param>
    /// <param name="time">The time to interpolate between the first and second key frame</param>
    /// <param name="curve">The movement curve between the two key frames</param>
    /// <param name="rate">	The movement mode between the two key frames</param>
    /// <param name="events">The events for the first key frame</param>
    /// <typeparam name="Q">Data type for the FlexiKeyFrame array</typeparam>
    /// <returns></returns>
    public static FlexiKeyFrame<Q>[] CreatePair<Q>(Q initial, Q final, float time, AnimationCurve curve=null,
                                                Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        if (initial == null || final == null)
            throw new NullReferenceException("One or more of the following cannot be null: 'initial', 'final'");
        if (time < 0)
            throw new ArgumentException("'time' cannot be less than 0");

        return new FlexiKeyFrame<Q>[] 
        {
            new FlexiKeyFrame<Q>(initial, time, curve, rate, events),
            new FlexiKeyFrame<Q>(final)
        };
    }

    /// <summary>
    /// Packs all given FlexiKeyFrames into an array of FlexiKeyFrames
    /// </summary>
    /// <param name="keyFrames">All of the key frames to be packed into an array</param>
    /// <typeparam name="Q">The type of the key frames</typeparam>
    /// <returns>keyFrames</returns>
    public static FlexiKeyFrame<Q>[] Pack<Q>(params FlexiKeyFrame<Q>[] keyFrames)
    {
        return keyFrames;
    }
}