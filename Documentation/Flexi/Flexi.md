# [Flexi](../Docs.md) : Flexi
<sub><sup>[Source Code](../../Source/Flexi.cs)</sup></sub>

## Public Delegates
| Delegate | Description |
| - | - |
| [Interpolate\<I>](Interpolate.md) | Delegate for the linear interpolation operation that will be applied to a data structure of type I |
| [Distance\<I>](Distance.md) | Delegate for calculating the distance between two instances of a data structure of type I |

## Public Enums
| Enum | Description |
| - | - |
| [Rate](Rate.md) | How the interpolation's time should function |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| [InterpolateInt\<T>](InterpolateInt.md) | int | Interpolates an int between each specified key frame |
| [InterpolateFloat\<T>](InterpolateFloat.md) | int | Interpolates a float between each specified key frame |
| [InterpolateVector2\<T>](InterpolateVector2.md) | int | Interpolates a Vector2 between each specified key frame |
| [InterpolateVector3\<T>](InterpolateVector3.md) | int | Interpolates a Vector3 between each specified key frame |
| [InterpolateVector4\<T>](InterpolateVector4.md) | int | Interpolates a Vector4 between each specified key frame |
| [InterpolateQuaternion\<T>](InterpolateQuaternion.md) | int | Interpolates a Quaternion between each specified key frame |
| [InterpolateColor\<T>](InterpolateColor.md) | int | Interpolates a Color between each specified key frame |
| [InterpolateGeneric\<T, I>](InterpolateGeneric.md) | int | Interpolates any data structure between each specified key frame |
| [Exists](Exists.md) | bool | Whether or not an interpolation with an ID of `id` exists |
| [Paused](Paused.md) | bool | If the interpolation with ID `id` is paused or not |
| [Pause](Pause.md) | void | Pauses the interpolation with ID `id` |
| [Resume](Resume.md) | void | Resumes the interpolation with ID `id` |
| [Cancel](Cancel.md) | void | Cancels the interpolation with ID `id` |

## Description
Handles the starting, stopping, and pausing of interpolations. Interpolations are represented as an array of [FlexiKeyFrame\<T>s](../FlexiKeyFrame/FlexiKeyFrame.md) that are iterated through in a coroutine
