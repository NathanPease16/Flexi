# [Flexi](../Docs.md) : [Flexi](Flexi.md) : InterpolateVector2\<T>
## Declaration #1
```cs
public static int InterpolateVector2<T>(T target, string property, FlexiKeyFrame<Vector2>[] keyFrames)
```
## Declaration #2
```cs
public static int InterpolateVector2<T>(T target, string property, Vector2 initial, Vector2 final, float time, AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| target | T | The object to search for `property` on |
| property | string | The property on `target` to modify |
| keyFrames | [FlexiKeyFrame](../FlexiKeyFrame/FlexiKeyFrame.md)\<Vector2>[] | The key frames to interpolate between |
| initial | Vector2 | The initial value of the interpolaiton |
| final | Vector2 | The final value of the interpolation |
| time | float | The length of the interpolation |
| curve | AnimationCurve | The movement curve for the interpolation |
| rate | [Rate](Rate.md) | The movement rate type of the interpolation |
| events | [FlexiEvent](../FlexiEvent/FlexiEvent.md)[] | Events to be invoked during the interpolation |

## Returns
The ID of the interpolation

## Description
Interpolates between all of the key frames, applying the changes each frame to `property` on `target`

Declaration #2 constructs a new FlexiKeyFrame array of type Vector2 using [FlexiKeyFrame.CreatePair\<Q>](../FlexiKeyFrame/CreatePairQ.md)

Acts as a Facade Method for [InterpolateGeneric](InterpolateGeneric.md), visit documentation on [InterpolateGeneric](InterpolateGeneric.md) for more information on how interpolations work behind the scenes
