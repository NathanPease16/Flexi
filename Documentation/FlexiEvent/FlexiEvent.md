# FlexiEvent Documentation
C# Event implementation for use with Flexi interpolations

## Public Constructors
| Constructor | Description |
| - | - |
| [FlexiEvent](FlexiEventConstructor.md) | Constructs a new FlexiEvent invoked at invocationPercentage percent through the interpolation |

## Public Methods
| Method | Return Type | Description |
| - | - | - |
| [Invoke](Invoke.md) | void | Invokes the FlexiEvent if `percentage` is greater than or equal to the invocation percentage |

## Static Methods
| Method | Return Type | Description |
| - | - | - |
| [Pack](Pack.md) | FlexiEvent[] | Combines any number of FlexiEvent objects into one array |

## Public Operators
| Operator | Other Type | Description |
| - | - | - |
| [+](+.md) | Action | Adds a new action as a subscriber to the FlexiEvent |
| [-](-.md) | Action | Unsubscribes the Action from the FlexiEvent |

