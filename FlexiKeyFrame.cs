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

    public FlexiKeyFrame(T value, float timeToNextKeyFrame=0f, AnimationCurve curve=null, Rate rate=Rate.time, 
                         FlexiEvent[] events=null)
    {
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

    public static FlexiKeyFrame<Q>[] CreatePair<Q>(Q initial, Q final, float time, AnimationCurve curve=null,
                                                Rate rate=Rate.time, FlexiEvent[] events=null)
    {
        return new FlexiKeyFrame<Q>[] 
        {
            new FlexiKeyFrame<Q>(initial, time, curve, rate, events),
            new FlexiKeyFrame<Q>(final)
        };
    }
}