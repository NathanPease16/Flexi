# [Flexi](../Docs.md) : FlexiEvent
<sub><sup>[Source](../../Source/FlexiEvent.cs)</sup></sub>

## Public Constructors
| Constructor | Description |
| - | - |
| [FlexiEvent](FlexiEventConstructor.md) | Constructs a new FlexiEvent object |

## Public Methods
| Method | Return Type | Description |
| - | - | - |
| [Invoke](Invoke.md) | void | Invokes the FlexiEvent if `percentage` is greater than or equal to the invocation percentage |
| [Uninvoke](Uninvoke.md) | void | Uninvokes the event |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| [Pack](Pack.md) | FlexiEvent[] | Combines any number of FlexiEvent objects into one array |

## Public Operators
| Operator | Other Type | Description |
| - | - | - |
| [+](+.md) | Action | Adds a new action as a subscriber to the FlexiEvent |
| [-](-.md) | Action | Unsubscribes the Action from the FlexiEvent |

## Description
FlexiEvents allow you to invoke events during an interpolation. Once the interpolation between two key frames reaches `invocationPercentage` percent completion (0.0f - 1.0f), the event will be invoked. After it is invoked, it will no longer be invoked again, unless the interpolation is restarted
