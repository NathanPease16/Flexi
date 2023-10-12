# FlexiKeyFrame\<T> Documentation
Stores data for key frames in an interpolation

## Public Properties
| Property | Type | Description |
| - | - | - |
| Value | T | The value of the key frame |
| TimeToNextKeyFrame | float | The time between this key frame and the next key frame in the interpolation |
| Curve | AnimationCurve | The movement curve for the key frame |
| Rate | Rate | The movement mode for the key frame |
| Events | FlexiEvent[] | All the events to be invoked during that key frame |

## Public Constructors
| Constructor | Description |
| - | - |
| FlexiKeyFrame | Creates a new FlexiKeyFrame object |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| CreatePair\<Q> | FlexiKeyFrame\<Q>[] | Creates an array of FlexiKeyFrames with a size of 2 using the given data |
