# Flexi Documentation

## Public Delegates
| Delegate | Declaration | Description |
| - | - | - |
| Operation | delegate T Operation\<T> (T a, T b, float t) | Delegate for the linear interpolation operation that will be applied to a data structure of type T |
| Distance | delegate float Distance\<T>(T a, T b) | Delegate for calculating the distance between two instances of a data structure of type T |

## Public Enums
| Enum | Description |
| - | - |
| [Rate](Rate.md) | How the interpolation's time should function |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| [InterpolateInt](InterpolateInt.md) | int | Interpolates an int between each specified key frame |
| [InterpolateFloat](InterpolateFloat.md) | int | Interpolates a float between each specified key frame |
| [InterpolateVector2](InterpolateVector2.md) | int | Interpolates a Vector2 between each specified key frame |
| [InterpolateVector3](InterpolateVector3.md) | int | Interpolates a Vector3 between each specified key frame |
| [InterpolateVector4](InterpolateVector4.md) | int | Interpolates a Vector4 between each specified key frame |
| [InterpolateQuaternion](InterpolateQuaternion.md) | int | Interpolates a Quaternion between each specified key frame |
| [InterpolateColor](InterpolateColor.md) | int | Interpolates a Color between each specified key frame |
| [InterpolateGeneric](InterpolateGeneric.md) | int | Interpolates any data structure between each specified key frame |
| [Exists](Exists.md) | bool | Whether or not an interpolation with an ID of `id` exists |
| [Paused](Paused.md) | bool | If the interpolation with ID `id` is paused or not |
| [Pause](Pause.md) | void | Pauses the interpolation with ID `id` |
| [Resume](Resume.md) | void | Resumes the interpolation with ID `id` |
| [Cancel](Cancel.md) | void | Cancels the interpolation with ID `id` |

## Description
Handles the starting, stopping, and pausing of interpolations. Interpolations are represented as an array of [FlexiKeyFrames](../FlexiKeyFrame/FlexiKeyFrame.md) that are iterated through in a coroutine
