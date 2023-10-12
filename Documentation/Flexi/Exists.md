# Flexi : Exists
## Declaration
```cs
public static bool Exists(int id)
```

## Parameters
| Parameter | Type | Description |
| - | - | - |
| id | int | The ID of the interpolation to check |

## Returns
`true` if the interpolation exists, `false` if it does not

## Description
Searches through all interpolations that have been started and not yet ended, and determines whether or not an interpolation with the given ID of `id` exists or not