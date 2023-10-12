# FlexiKeyFrame\<T> Documentation

## Public Properties
| Property | Type | Description |
| - | - | - |
| Value | T | The value of the key frame |
| TimeToNextKeyFrame | float | The time between this key frame and the next key frame in the interpolation |
| Curve | AnimationCurve | The movement curve for the key frame |
| Rate | [Rate](../Flexi/Rate.md) | The movement mode for the key frame |
| Events | [FlexiEvent](../FlexiEvent/FlexiEvent.md)[] | All the events to be invoked during that key frame |

## Public Constructors
| Constructor | Description |
| - | - |
| [FlexiKeyFrame](FlexiKeyFrameConstructor.md) | Creates a new FlexiKeyFrame object |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| [CreatePair\<Q>](CreatePairQ.md) | FlexiKeyFrame\<Q>[] | Creates an array of FlexiKeyFrames with a size of 2 using the given data |

## Description
Stores data for key frames in an interpolation. 

When evaluated in the interpolation, all key frames will be represented as an array of FlexiKeyFrames. Similarly to a Unity animation, it will traverse through each key frame in the array (excluding the last key frame) and interpolate between the current and next key frame using the current key frame's `TimeTonextKeyFrame` as the length of the interpolation, `Curve` as the [movement curve](../FlexiCurves/FlexiCurves.md), `Rate` as the [rate mode](../Flexi/Rate.md), and `Event` as any [events](..FlexiEvent/FlexiEvent.md) to be called during interpolation. Time is relative for each key frame in the interpolation
