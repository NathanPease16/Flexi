# [Flexi](../Docs.md) : [FlexiKeyFrame\<T>](FlexiKeyFrame.md) : CreatePair\<K>
## Declaration
```cs
public static FlexiKeyFrame<K>[] CreatePair<K>(K initial, K final, float time, AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| initial | K | The value of the first key frame |
| final | K | The value of the second key frame |
| time | float | The time to interpolate between the first and second key frame |
| curve | AnimationCurve | The movement curve between the two key frames |
| rate | [Rate](../Flexi/Rate.md) | The movement mode between the two key frames |
| events | [FlexiEvent](../FlexiEvent/FlexiEvent.md)[] | The events for the first key frame |

## Description
Creates a pair of key frames as an array using the given data as the values for the key frames
