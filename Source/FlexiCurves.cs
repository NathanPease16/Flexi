using UnityEngine;

/// <summary>
/// Stores pre-defined movement curves for ease of use
/// </summary>
public static class FlexiCurves
{
    #region Keyframes
    private static Keyframe[] linearKeys = new Keyframe[] { new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1) };
    private static Keyframe[] quadraticKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 2, 0) };
    private static Keyframe[] cubicKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 3, 0) };
    private static Keyframe[] bouncingKeys = new Keyframe[] { new Keyframe(0, 0, 0, -1.5f), new Keyframe(1, 1, -1.5f, 0) };
    private static Keyframe[] overshootKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, -1.5f, 0) };
    private static Keyframe[] recoveryKeys = new Keyframe[] { new Keyframe(0, 0, 0, -1.5f), new Keyframe(1, 1, 0, 0) };
    private static Keyframe[] easeInKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 1, 0, .25f, 0) };
    private static Keyframe[] easeOutKeys = new Keyframe[] { new Keyframe(0, 0, 0, 1, 0, .25f), new Keyframe(1, 1, 0, 0) };
    private static Keyframe[] easeInOutKeys = new Keyframe[] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 0, 0) };
    #endregion

    #region Curves
    public static readonly AnimationCurve linear = new AnimationCurve(linearKeys);
    public static readonly AnimationCurve quadratic = new AnimationCurve(quadraticKeys);
    public static readonly AnimationCurve cubic = new AnimationCurve(cubicKeys);
    public static readonly AnimationCurve bouncing = new AnimationCurve(bouncingKeys);
    public static readonly AnimationCurve overshoot = new AnimationCurve(overshootKeys);
    public static readonly AnimationCurve recovery = new AnimationCurve(recoveryKeys);
    public static readonly AnimationCurve easeIn = new AnimationCurve(easeInKeys);
    public static readonly AnimationCurve easeOut = new AnimationCurve(easeOutKeys);
    public static readonly AnimationCurve easeInOut = new AnimationCurve(easeInOutKeys);
    #endregion
}