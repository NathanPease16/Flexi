# Getting Started with Flexi

## Importing Flexi
Before you can use Flexi in your project, you have to import it. An importation guide can be found [here](Import.md)

## Interpolating Your First Value
Once you have successfully imported Flexi, you're one step closer to interpolating values! Start by creating a new MonoBehaviour, you can call it whatever you'd like. Remove the Update method, and add a serialized private field of type float and a public property for that field. If you are unsure what a field or property is, you can check out [this resource](https://medium.com/omarelgabrys-blog/properties-vs-fields-in-c-6cec86c59dc9) for more information!
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private float _value;
    public float Value { get { return _value; } set { _value = value; } }

    void Start()
    {

    }
}
```

Next, you'll want to tell Flexi to interpolate the property (not the field). Create 3 float variables, one for `initial`, one for `final`, and one for `time`, and call the [InterpolateFloat](../Flexi/InterpolateFloat.md) method. When calling [InterpolateFloat](../Flexi/InterpolateFloat.md), we have to give it 5 pieces of information. The first two are `target` and `property`. `target` is the object you want to search for `property` on, and `property` is the property to look for. `initial` is the initial value of the interpolation, `final` is the final value of the interpolation, and `time` is how long it takes. In the example below, we interpolate the property `Value` on `this` (the current object) from `_initial` (0.0f) to `_final` (10.0f) over `_time` (5.0f) seconds. When you run your Unity project, you should be able to see in the inspector that `_value` is increasing linearly, getting to a value of 10 after 5 seconds
```cs
public class Example : MonoBehaviour
{
    [SerializeField] private float _value;
    public float Value { get { return _value; } set { _value = value; } }

    [SerializeField] private float _initial = 0.0f;
    [SerializeField] private float _final = 10.0f;
    [SerializeField] private float _time = 5.0f;

    void Start()
    {
        Flexi.InterpolateFloat(this, "Value", _initial, _final, _time);
    }
}
```
Now you have a working interpolation!

To explore all of Flexi's features, you can visit other tutorials [here](Tutorials.md)!