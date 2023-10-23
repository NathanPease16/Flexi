# Flexi
Flexi is a lightweight interpolation package designed to be the optimized, feature-rich successor to WiggleWarp

Don't know how to import Flexi? Try [here](Tutorials/Import.md)

Need help getting started? Check out some of [these tutorials](Tutorials/Tutorials.md)

## Features
- 7 data types with [native support](FlexiOperations/FlexiOperations.md)
  - int, float, Vector2, Vector3, Vector4, Quaternion, Color
- Support for [custom data types](Flexi/InterpolateGeneric.md) and custom implementations of [natively supported data types](FlexiOperations/FlexiOperations.md)
- 9 pre-defined [movement curves](FlexiCurves/FlexiCurves.md)
  - linear, quadratic, cubic, bouncing, overshoot, recovery, ease-in, ease-out, ease-in-out
- Support for [custom movement curves](FlexiKeyFrame/FlexiKeyFrameConstructor.md)
- 2 [rate types](Flexi/Rate.md)
  - time, speed
- Pausing, resuming, and canceling [interpolations](Flexi/Flexi.md)
- [Interpolation events](FlexiEvent/FlexiEvent.md)
- [Interpolation with key frames](FlexiKeyFrame/FlexiKeyFrame.md)

## Classes
| Class | Description
| - | - |
| [Flexi](Flexi/Flexi.md) | Main class for executing and performing operations on interpolations |
| [FlexiKeyFrame\<T>](FlexiKeyFrame/FlexiKeyFrame.md) | Stores data for a key frame in an interpolation |
| [FlexiCurves](FlexiCurves/FlexiCurves.md) | Stores pre-defined movement curves for ease of use |
| [FlexiEvent](FlexiEvent/FlexiEvent.md) | Events that can be called during a Flexi interpolation |
| [FlexiOperations](FlexiOperations/FlexiOperations.md) | Native implementations of operations for each supported data type |
