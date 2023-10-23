# [Flexi](../Docs.md) : [Flexi](Flexi.md) : Rate
## Members
| Member | Description |
| - | - |
| time | The interpolation will take the same amount of time, regardless of distane |
| speed | The interpolation will move at the same speed, regardless of how long it takes to complete |

## Description
Determines how the interpolation will move. If a [FlexiKeyFrame\<T>](../FlexiKeyFrame/FlexiKeyFrame.md)'s movement rate is set to `time`,
it will complete the interpolation between itself and the next key frame over a set amount of time, regardless of how much distane it has to cover (time is constant). If its movement rate is set to `speed`, it will move at the same speed during its interpolation, regardless of how much distance it has to cover (speed is constant)
