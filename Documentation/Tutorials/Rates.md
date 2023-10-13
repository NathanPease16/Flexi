# Movement Rates in Flexi

## What Are Movement Rates?
Movement rates allow you to control how your interpolation interprets `time`. A movement rate of `time` means time will stay constant, and thus it will move faster the larger the distance between `initial` and `final`. `speed`, on the other hand, means that speed will stay constant, and thus it will take longer the farther the distance between `initial` and `final`. `time` tells the interpolation to move over the span of x seconds, while `speed` tells the interpolation to move at x units/second. Every interpolation defaults to a movement rate type of `time`

## Interpolating With a Different Movement Rate
Start off by creating a simple interpolation between two values. If you are unsure how to do this, check out [this tutorial](GettingStarted.md)
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private Color _value;
    public Color Value { get { return _value; } set { _value = value; } }

    [SerializeField] private Color _initial = Color.white;
    [SerializeField] private Color _final = Color.red;
    [SerializeField] private float _time = .05f;

    void Start()
    {
        Flexi.InterpolateColor(this, "Value", _initial, _final, _time);
    }
}
```
This still interpolates over time, however, as that is the default value. To change this, we simply add `Rate.speed` as an argument for the parameter `rate`. More information on `rate's` members can be found [here](../Flexi/Rate.md). is an option parameter, so it is good practice to write out `rate: ` so it knows which optional parameter is being referenced
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private Color _value;
    public Color Value { get { return _value; } set { _value = value; } }

    [SerializeField] private Color _initial = Color.white;
    [SerializeField] private Color _final = Color.red;
    [SerializeField] private float _time = .05f;

    void Start()
    {
        Flexi.InterpolateColor(this, "Value", _initial, _final, _time, rate: Rate.speed);
    }
}
``` 
And just like that the interpolation is now based on Units / Second rather than Seconds!

To explore all of Flexi's features, you can visit other tutorials [here](Tutorials.md)!