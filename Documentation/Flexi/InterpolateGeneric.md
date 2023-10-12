# [Flexi](../Docs.md) : [Flexi](Flexi.md) : InterpolateGeneric\<T, Q>
## Declaration
```cs
public static int InterpolateGeneric<T, Q>(Q target, string property, Operation<T> op, Distance<T> dist, FlexiKeyFrame<T>[] keyFrames)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| target | Q | The object to search for `property` on |
| property | string | The property on `target` to modify |
| op | Operation\<T> | The operation used to calculate linear interpolation at a point `t` |
| dist | Distance\<T> | Method used to calculate distance between two objects of the same type |
| keyFrames | FlexiKeyFrame\<T>[] | The key frames to interpolate between |

## Returns
The ID of the interpolation

## Description
InterpolateGeneric is the main method used to handle interpolations. When Facade Methods (such as [InterpolateFloat](InterpolateFloat.md) or [InterpolateVector3](InterpolateVector3.md)) are called, they pass along all of their information to InterpolateGeneric, which does the bulk of the work. It uses `target` and `property` to directly modifying that specified property of `target` during the interpolation. It starts a coroutine that loops through every single key frame except for the last one and interpolates between the current and next key frame using the [curve](../FlexiCurves/FlexiCurves.md) and [rate](Rate.md) (time or speed) given by the current key frame
