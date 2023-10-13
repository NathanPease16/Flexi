# Movement Curves in Flexi

## What are Movement Curves?
In Flexi, Movement Curves, represented by Unity's AnimationCurve, allow you to control `t` in the [Interpolate](../FlexiOperations/FlexiOperations.md) method of your interpolation. Interpolations in Flexi go from 0 to 1 (represented by `t`), with 0 representing the beginning of the interpolation (0%) and 1 representing the end of the interpolation (100%). At each interval in the interpolation, a new `current` value is calculated with the value of `initial`, the value of `final`, and `t` using an [Interpolate](../FlexiOperations/FlexiOperations.md) method. When you apply a curve to an interpolation, that curve will be evaluated at `t` (x), and the output will be used in the Interpolate method in place of `t`. For example, if `initial` is 0, `final` is 1, `t` is 0.5f, and you have a curve representing y = x<sup>2</sup>, the value of `current` half way through the interpolation would be 0.25f, as t<sup>2</sup> = 0.25f and the interpolation between 0 and 1 at 0.25f is 0.25f. Every interpolation defaults to a linear curve

## Interpolating a Value with a Pre-Defined Curve
Start by creating a basic interpolation between two values with a curve, this can be of any data type. If you are unsure how to do this, check out [this tutorial](GettingStarted.md)
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private Vector2 _value;
    public Vector2 Value { get { return _value; } set { _value = value; } }

    [SerializeField] private Vector2 _initial = Vector2.zero;
    [SerializeField] private Vector2 _final = Vector2.up * 5f;
    [SerializeField] private float _time = 2.5f;

    void Start()
    {
        Flexi.InterpolateVector2(this, "Value", _initial, _final, _time);
    }
}
```

Next, simply add the curve as the next argument for the parameter `curve`. Since `curve` is an optional parameter, it's good practice to write `curve: ` before the argument so it knows which optional parameter is being referenced. A full list of curves in Flexi can be found [here](../FlexiCurves/FlexiCurves.md)
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private Vector2 _value;
    public Vector2 Value { get { return _value; } set { _value = value; } }

    [SerializeField] private Vector2 _initial = Vector2.zero;
    [SerializeField] private Vector2 _final = Vector2.up * 5f;
    [SerializeField] private float _time = 2.5f;

    void Start()
    {
        Flexi.InterpolateVector2(this, "Value", _initial, _final, _time, curve: FlexiCurves.bouncing);
    }
}
```

## Interpolating a Value with a Custom Curve
Interpolating a value with a custom curve is only slightly more invovled than with a pre-defined curve. Once again, start with a basic interpolation between two values
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private Vector2 _value;
    public Vector2 Value { get { return _value; } set { _value = value; } }

    [SerializeField] private Vector2 _initial = Vector2.zero;
    [SerializeField] private Vector2 _final = Vector2.up * 5f;
    [SerializeField] private float _time = 2.5f;

    void Start()
    {
        Flexi.InterpolateVector2(this, "Value", _initial, _final, _time);
    }
}
``` 
Next, simply add an AnimationCurve variable, and use it as the curve instead of a curve defined in the Flexi package
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private Vector2 _value;
    public Vector2 Value { get { return _value; } set { _value = value; } }

    [SerializeField] private Vector2 _initial = Vector2.zero;
    [SerializeField] private Vector2 _final = Vector2.up * 5f;
    [SerializeField] private float _time = 2.5f;

    [SerializeField] private AnimationCurve _curve;

    void Start()
    {
        Flexi.InterpolateVector2(this, "Value", _initial, _final, _time, curve: _curve);
    }
}
```
Now you have an interpolation that uses a curve for its evaluation!

To explore all of Flexi's features, you can visit other tutorials [here](Tutorials.md)!