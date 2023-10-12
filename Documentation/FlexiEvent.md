# FlexiEvent Documentation
C# Event implementation for use with Flexi interpolations

## Constructors
| Constructor | Description |
| - | - |
| [FlexiEvent](FlexiEvent.md#FlexiEvent) | Constructs a new FlexiEvent invoked at invocationPercentage percent through the interpolation |

## FlexiEvent
```cs
public FlexiEvent(float invocationPercentage)
```
| Parameter | Type | Description |
| - | - | - |
| invocationPercentage | float | The percentage through the interpolation key frame when the event should be invoked |

### Returns
The newly constructed FlexiEvent object

### Description
Creates a new FlexiEvent object with the specified invocation percentage value
