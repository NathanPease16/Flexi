# Events in Flexi

## What are FlexiEvents?
During an interpolation, you may want to have code separate from the interpolation to run. This can be achieved through [FlexiEvents](../FlexiEvent/FlexiEvent.md). Generally, events have subscribers (or observers, listeners), and when an event is fired (or invoked), the subscribers will then run their code

In Flexi, you can use [FlexiEvents](../FlexiEvent/FlexiEvent.md) to call code at a certain point in the interpolation between two key frames (relative and represented as a decimal percent)

## Firing a Simple FlexiEvent
Start by creating an interpolation between two values. If you are unsure of how to do this, you can check out [this tutorial](GettingStarted.md)
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private float _value;
    public float Value { get { return _value; } set { _value = value; } }

    [SerializeField] private float _initial = 0f;
    [SerializeField] private float _final = 200f;
    [SerializeField] private float _time = 200f;

    void Start()
    {
        Flexi.InterpolateFloat(this, "Value", _initial, _final, _time);
    }
}
```

Next, create a new FlexiEvent object and a method to subscribe to the event. This method should have a return type of void and have no parameters. Flexi does not currently support events with parameters, though support will likely be added in the future.