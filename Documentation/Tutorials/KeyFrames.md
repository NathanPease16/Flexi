# Keyframes in Flexi

## What Are FlexiKeyframes?
Keyframes in Flexi work similarly to keyframes in an animation. They allow you to have an interpolation that interpolates between multiple different states, instead of just two different values. [FlexiKeyframes](../FlexiKeyFrame/FlexiKeyFrame.md) are interpreted as an array of FlexiKeyframe objects, where Flexi interpolates between the current and next [FlexiKeyframe](../FlexiKeyFrame/FlexiKeyFrame.md) in the array. The interpolation uses the ***current*** [FlexiKeyframe](../FlexiKeyFrame/FlexiKeyFrame.md) object's values to interpolate between current and next.

## Creating Keyframes
There are two main ways to create a [FlexiKeyframe](../FlexiKeyFrame/FlexiKeyFrame.md):
1) Create new instances of [FlexiKeyframe](../FlexiKeyFrame/FlexiKeyFrame.md) objects with its constructor
2) Use the custom Unity Editor script to quickly build [FlexiKeyframe](../FlexiKeyFrame/FlexiKeyFrame.md) objects

## Creating Keyframes with the Constructor
Creating Keyframes in Flexi with the [constructor](../FlexiKeyFrame/FlexiKeyFrameConstructor.md) is relatively simple, the constructor is defined as such:
```cs
public FlexiKeyFrame(T value, float timeToNextKeyFrame=0f, AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
```

Thus, to create a [FlexiKeyFrame](../FlexiKeyFrame/FlexiKeyFrame.md) all you have to do is specify the type and give it the parameters you want! For information on how to use rates, animation curves, and events, check out [these other tutorials](./Tutorials.md)

```cs
public class Example : MonoBehaviour
{
    private float _initial;
    private float _time;

    void Start()
    {
        FlexiKeyFrame<float> keyframe = new FlexiKeyFrame<float>(_initial, _time);
    }
}
```

However, to use [FlexiKeyFrames](../FlexiKeyFrame/FlexiKeyFrame.md) with Flexi, you have to give Flexi an array of [FlexiKeyFrames](../FlexiKeyFrame/FlexiKeyFrame.md). Luckily, this is made easy with the static [FlexiKeyFrame.Pack](../FlexiKeyFrame/PackK.md) method, which is declared as such:

```cs
public static FlexiKeyFrame<K>[] Pack<K>(params FlexiKeyFrame<K>[] keyFrames)
```

This method allows you to pass any number of [FlexiKeyFrames](../FlexiKeyFrame/FlexiKeyFrame.md) and it will automatically package them into an array for you!

```cs
public class Example : MonoBehaviour
{
    [SerializeField] private float _target;
    public float Target { get { return _target; } set { _target = value; } }

    private float _initial = 0f;
    private float _final = 10f;
    private float _time = 3f;

    void Start()
    {
        FlexiKeyFrame<float> start = new FlexiKeyFrame<float>(_initial, _time);
        FlexiKeyFrame<float> end = new FlexiKeyFrame<float>(_final);

        // Can use any number of keyframes (i.e. FlexiKeyFrame.Pack(one, two, three, four, ...));
        FlexiKeyFrame<float>[] keyframes = FlexiKeyFrame.Pack(start, end);

        Flexi.InterpolateFloat(this, "Target", keyframes);
    }
}
```

## Creating keyframes with the Custom Unity Editor Script
Creating [FlexiKeyFrames](../FlexiKeyFrame/FlexiKeyFrame.md) is simple enough as is with the constructor, but the process is further streamlined by using the custom [FlexiKeyFrame](../FlexiKeyFrame/FlexiKeyFrame.md) Unity editor! Just by having an array of [FlexiKeyFrames](../FlexiKeyFrame/FlexiKeyFrame.md) exposed in the editor (i.e. public, [SerializeField]) you can easily and intuitively edit the properties of the keyframe.

To explore all of Flexi's features, you can visit other tutorials [here](Tutorials.md)!