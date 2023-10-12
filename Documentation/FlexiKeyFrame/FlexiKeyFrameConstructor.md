# FlexiKeyFrame\<T> : Constructor
## Declaration
```cs
public FlexiKeyFrame(T value, float timeToNextKeyFrame=0f, AnimationCurve curve=null, Rate rate=Rate.time, FlexiEvent[] events=null)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| value | T | The value of the key frame |
| timeToNextKeyFrame | float | The time to interpolate between this key frame and the next key frame |
| curve | AnimationCurve | The movement curve for this key frame |
| rate | [Rate](../Flexi/Rate.md) | The rate mode for this key frame |
| events | [FlexiEvent](../FlexiEvent/FlexiEvent.md)[] | All events to be called during this key frame |

## Description
Creates a new FlexiKeyFrame object
