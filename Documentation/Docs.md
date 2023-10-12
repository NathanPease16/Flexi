# Flexi Documentation
Flexi is a lightweight interpolation package designed to be the optimized, feature-rich successor to WiggleWarp

## Features
- 7 data types with native support
  - int, float, Vector2, Vector3, Vector4, Quaternion, Color
- Support for custom data types and custom implementations of natively supported data types
- 9 pre-defined movement curves
  - linear, quadratic, cubic, bouncing, overshoot, recovery, ease-in, ease-out, ease-in-out
- Support for custom movement curves
- 2 movement types
  - speed, rate
- Pausing, resuming, and canceling interpolations
- Interpolation events
- Interpolation key frames

## Classes
| Class | Description
| - | - |
| [Flexi]: https://github.com/NathanPease16/Flexi/blob/main/Documentation/Flexi.md | Main class for executing and performing operations on interpolations |
| FlexiKeyFrame | Stores data for key frames in an interpolation |
| FlexiCurves | Stores pre-defined movement curves for ease of use |
| FlexiEvent | C# Event implementation for use with Flexi interpolations |
| FlexiOperations | Native implementations of operations for each data type |
