using System;

public class FlexiEvent
{
    public event Action _flexiEvent;
    private float _invocationPercentage; 
    private bool _invoked;

    public FlexiEvent(float invocationPercentage)
    {
        _invocationPercentage = invocationPercentage;
    }

    public void Invoke(float percentage)
    {
        if (!_invoked && percentage >= _invocationPercentage)
        {
            _flexiEvent?.Invoke();
            _invoked = true;
        }
    }

    public static FlexiEvent[] Pack(params FlexiEvent[] events)
    {
        return events;
    }

    public static FlexiEvent operator +(FlexiEvent flexiEvent, Action newEvent)
    {
        flexiEvent._flexiEvent += newEvent;
        return flexiEvent;
    }

    public static FlexiEvent operator -(FlexiEvent flexiEvent, Action oldEvent)
    {
        flexiEvent._flexiEvent -= oldEvent;
        return flexiEvent;
    }
}
