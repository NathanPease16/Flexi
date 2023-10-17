using UnityEngine;
using System;
using UnityEngine.Events;

/// <summary>
/// An event that can be invoked during an interpolation
/// </summary>
[Serializable]
public class FlexiEvent
{
    [SerializeField] private UnityEvent _event;
    [SerializeField] private float _invokePercent; 
    private bool _invoked;

    /// <summary>
    /// Creates a new FlexiEvent object with the specified invocation percentage value
    /// </summary>
    /// <param name="invocationPercentage">The time during the interpolation between two key frames the event should be invoked (represented as a decimal percent)</param>
    public FlexiEvent(float invocationPercentage)
    {
        _invokePercent = invocationPercentage;
    }

    /// <summary>
    /// If percentage, which represents the current percent through the interpolation, is greater than or equal to the specified invocation percentage, the FlexiEvent will be invoked once and never again during that interpolation
    /// </summary>
    /// <param name="percentage">The current percentage through the interpolation</param>
    public void Invoke(float percentage)
    {
        if (!_invoked && percentage >= _invokePercent)
        {
            _event?.Invoke();
            _invoked = true;
        }
    }

    /// <summary>
    /// Uninvokes the event so it can be invoked again
    /// </summary>
    public void Uninvoke()
    {
        _invoked = false;
    }

    /// <summary>
    /// Packs all given FlexiEvents into an array of FlexiEvents
    /// </summary>
    /// <param name="events">All of the events to be packed into an array</param>
    /// <returns>The FlexiEvents packed into an array</returns>
    public static FlexiEvent[] Pack(params FlexiEvent[] events)
    {
        return events;
    }

    /// <summary>
    /// Adds a new subscriber to flexiEvent
    /// </summary>
    /// <param name="flexiEvent">The FlexiEvent object newSubscriber will be subscribed to</param>
    /// <param name="newSubscriber">The Action to subscribe to flexiEvent</param>
    /// <returns>flexiEvent</returns>
    public static FlexiEvent operator +(FlexiEvent flexiEvent, UnityAction newSubscriber)
    {
        //flexiEvent._flexiEvent += newSubscriber;
        flexiEvent._event.AddListener(newSubscriber);
        return flexiEvent;
    }

    /// <summary>
    /// Removes a subscriber from flexiEvent
    /// </summary>
    /// <param name="flexiEvent">The FlexiEvent object newSubscriber will be unsubscribed from</param>
    /// <param name="oldSubscriber">The Action to unsubscribe from flexiEvent</param>
    /// <returns>flexiEvent</returns>
    public static FlexiEvent operator -(FlexiEvent flexiEvent, UnityAction oldSubscriber)
    {
        flexiEvent._event.RemoveListener(oldSubscriber);
        return flexiEvent;
    }
}
