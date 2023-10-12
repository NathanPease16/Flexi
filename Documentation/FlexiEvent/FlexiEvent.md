# FlexiEvent Documentation
C# Event implementation for use with Flexi interpolations

## Public Constructors
| Constructor | Description |
| - | - |
| [FlexiEvent](FlexiEvent.md#FlexiEvent) | Constructs a new FlexiEvent invoked at invocationPercentage percent through the interpolation |

## Public Methods
| Method | Return Type | Description |
| - | - | - |
| Invoke | void | Invokes the FlexiEvent if `percentage` is greater than or equal to the invocation percentage |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| Pack | FlexiEvent[] | Combines any number of FlexiEvent objects into one array |

## Public Operators
| Operator | Other Type | Description |
| - | - | - |
| + | Action | Adds a new action as a subscriber to the FlexiEvent |
| - | Action | Unsubscribes the Action from the FlexiEvent |

------------------------------------------------------------

&nbsp;
## FlexiEvent
### Declaration
```cs
public FlexiEvent(float invocationPercentage)
```

### Parameters
| Parameter | Type | Description |
| - | - | - |
| invocationPercentage | float | The percentage through the interpolation key frame when the event should be invoked |

### Description
Creates a new FlexiEvent object with the specified invocation percentage value

------------------------------------------------------------

&nbsp;
## Invoke
### Declaration
```cs
public void Invoke(float percentage)
```

### Parameters
| Parameter | Type | Description |
| - | - | - |
| percentage | float | The current percentage through the interpolation |

### Description
If `percentage,` which represents the current percent through the interpolation, is greater than or equal to the specified invocation percentage, the FlexiEvent will be invoked once and never again during that interpolation

## Pack
### Declaration
```cs
public static FlexiEvent[] Pack(params FlexiEvent[] events)
```

### Parameters
| Parameter | Type | Description |
| - | - | - |
| events | FlexiEvent[] | All of the events to be packed into an array |



