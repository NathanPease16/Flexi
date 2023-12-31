# [Flexi](../Docs.md) : [Flexi](Flexi.md) : InterpolateVector3\<T>
## Declaration #1
```cs
public static int InterpolateVector3<T>(T target, string property, FlexiKeyFrame<Vector3>[] keyFrames)
```
## Declaration #2
```cs
public static int InterpolateVector3<T>(T target, string property, Vector3 initial, Vector3 final, float time, AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| target | T | The object to search for `property` on |
| property | string | The property on `target` to modify |
| keyFrames | [FlexiKeyFrame](../FlexiKeyFrame/FlexiKeyFrame.md)\<Vector3>[] | The key frames to interpolate between |
| initial | Vector3 | The initial value of the interpolaiton |
| final | Vector3 | The final value of the interpolation |
| time | float | The length of the interpolation |
| curve | AnimationCurve | The movement curve for the interpolation |
| rate | [Rate](Rate.md) | The movement rate type of the interpolation |
| events | [FlexiEvent](../FlexiEvent/FlexiEvent.md)[] | Events to be invoked during the interpolation |

## Returns
The ID of the interpolation

## Description
Interpolates between all of the key frames, applying the changes each frame to `property` on `target`

Declaration #2 constructs a new [FlexiKeyFrame\<Vector3>](../FlexiKeyFrame/FlexiKeyFrame.md) array using [FlexiKeyFrame\<T>.CreatePair\<K>](../FlexiKeyFrame/CreatePairK.md)

Acts as a Facade Method for [InterpolateGeneric<T, I>](InterpolateGeneric.md), visit documentation on [InterpolateGeneric<T, I>](InterpolateGeneric.md) for more information on how interpolations work behind the scenes
