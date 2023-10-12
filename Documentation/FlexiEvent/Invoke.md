# [Flexi](../Docs.md) : [FlexiEvent](FlexiEvent.md) : Invoke
## Declaration
```cs
public void Invoke(float percentage)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| percentage | float | The current percentage through the interpolation |

## Description
If `percentage,` which represents the current percent through the interpolation, is greater than or equal to the specified invocation percentage, the FlexiEvent will be invoked once and never again during that interpolation
