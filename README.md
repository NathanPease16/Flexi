# Flexi
Flexi is designed to be a simple, feature-rich interpolation package for the Unity game engine

Need help importing Flexi? Try [this](./Documentation/Tutorials/Install.md)

Don't know how to get started? Check out some of [these tutorials](./Documentation/Tutorials/Tutorials.md)

## Features
- 7 data types with [native support](./Documentation/FlexiOperations/FlexiOperations.md)
  - int, float, Vector2, Vector3, Vector4, Quaternion, Color
- Support for [custom data types](./Documentation/Flexi/InterpolateGeneric.md) and custom implementations of [natively supported data types](./Documentation/FlexiOperations/FlexiOperations.md)
- 9 pre-defined [movement curves](./Documentation/FlexiCurves/FlexiCurves.md)
  - linear, quadratic, cubic, bouncing, overshoot, recovery, ease-in, ease-out, ease-in-out
- Support for [custom movement curves](./Documentation/FlexiKeyFrame/FlexiKeyFrameConstructor.md)
- 2 [rate types](./Documentation/Flexi/Rate.md)
  - time, speed
- Pausing, resuming, and canceling [interpolations](./Documentation/Flexi/Flexi.md)
- [Interpolation events](./Documentation/FlexiEvent/FlexiEvent.md)
- [Interpolation with key frames](./Documentation/FlexiKeyFrame/FlexiKeyFrame.md)

## Classes
| Class | Description
| - | - |
| [Flexi](./Documentation/Flexi/Flexi.md) | Main class for executing and performing operations on interpolations |
| [FlexiKeyFrame\<T>](./Documentation/FlexiKeyFrame/FlexiKeyFrame.md) | Stores data for a key frame in an interpolation |
| [FlexiCurves](./Documentation/FlexiCurves/FlexiCurves.md) | Stores pre-defined movement curves for ease of use |
| [FlexiEvent](./Documentation/FlexiEvent/FlexiEvent.md) | Events that can be called during a Flexi interpolation |
| [FlexiOperations](./Documentation/FlexiOperations/FlexiOperations.md) | Native implementations of operations for each supported data type |
