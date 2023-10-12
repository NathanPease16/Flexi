# Flexi Documentation
Flexi is a lightweight interpolation package designed to be the optimized successor to WiggleWarp

## Features
- 7 data types with native support
  - int, float, Vector2, Vector3, Vector4, Quaternion, Color
- Support for custom data types
- 9 pre-defined movement curves
  - linear, quadratic, cubic, bouncing, overshoot, recovery, ease-in, ease-out, ease-in-out
- Support for custom movement curves
- 2 movement types
  - speed, rate
- Pausing, resuming, and canceling interpolations
- Interpolation events

## Curves
| Curve | Description |
| ----------- | ----------- |
| linear| A curve representing v = t |
| quadratic | A curve representing v = t<sup>2</sup> |
| cubic | A curve representing v = t<sup>3</sup> |
| bouncing | Dips slightly below 0, linearly increases past 1, and then settles at 1 |
| overshoot | Linearly increases past 1 and then settles at 1 |
| recovery | Dips below 0 and then linearly increases to 1 |
| easeIn | Eases into a linear line towards 1 |
| easeOut | Eases out of a linear line towards 1 |
| easeInOut| Eases into and out of a linear line towards 1 |
