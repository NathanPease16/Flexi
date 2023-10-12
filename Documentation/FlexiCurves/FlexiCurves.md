# [Flexi](../Docs.md) : FlexiCurves

## Public Fields
| Property | Type | Description |
| - | - | - |
| linear | AnimationCurve | Represents v = t |
| quadratic | AnimationCurve | Represents v = t<sup>2</sup> |
| cubic | AnimationCurve | Represents v = t<sup>3</sup> |
| bouncing | AnimationCurve | Dips slightly below 0, linearly increases past 1, and then settles at 1 |
| overshoot | AnimationCurve | Linearly increases past 1 and then settles at 1 |
| recovery | AnimationCurve | Dips below 0 and then linearly increases to 1 |
| easeIn | AnimationCurve | Eases into a linear line towards 1 |
| easeOut | AnimationCurve | Eases out of a linear line towards 1 |
| easeInOut| AnimationCurve | Eases into and out of a linear line towards 1 |

## Description
Stores pre-defined movement curves for ease of use

When applied to an interpolation, the curve will be evaluted at the interpolation's current completion percentage (0.0f - 1.0f) and used as `t` in all [FlexiOperations](../FlexiOperations/FlexiOperations.md)
