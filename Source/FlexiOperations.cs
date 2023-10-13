using UnityEngine;

public static class FlexiOperations
{
    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first int</param>
    /// <param name="b">The second int</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static int IntOp(int a, int b, float t) => (int)Mathf.LerpUnclamped(a, b, t);

    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first float</param>
    /// <param name="b">The second float</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static float FloatOp(float a, float b, float t) => Mathf.LerpUnclamped(a, b, t);

    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first Vector2</param>
    /// <param name="b">The second Vector2</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static Vector2 Vector2Op(Vector2 a, Vector2 b, float t)
    {
        return new Vector2
        (
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t)
        );
    }

    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first Vector3</param>
    /// <param name="b">The second Vector3</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static Vector3 Vector3Op(Vector3 a, Vector3 b, float t)
    {
        return new Vector3
        (
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t),
            Mathf.LerpUnclamped(a.z, b.z, t)
        );
    }

    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first Vector4</param>
    /// <param name="b">The second Vector4</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static Vector4 Vector4Op(Vector4 a, Vector4 b, float t)
    {
        return new Vector4
        (
            Mathf.LerpUnclamped(a.w, b.w, t),
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t),
            Mathf.LerpUnclamped(a.z, b.z, t)
        );
    }

    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first Quaternion</param>
    /// <param name="b">The second Quaternion</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static Quaternion QuaternionOp(Quaternion a, Quaternion b, float t)
    {
        Vector3 opEuler = Vector3Op(a.eulerAngles, b.eulerAngles, t);

        return Quaternion.Euler(opEuler.x, opEuler.y, opEuler.z);
    }

    /// <summary>
    /// Calculates and returns the linear interpolation between a and b in regards to t
    /// </summary>
    /// <param name="a">The first Color</param>
    /// <param name="b">The second Color</param>
    /// <param name="t">Interpolation value</param>
    /// <returns>The interpolated value</returns>
    public static Color ColorOp(Color a, Color b, float t)
    {
        return new Color
        (
            Mathf.LerpUnclamped(a.r, b.r, t),
            Mathf.LerpUnclamped(a.g, b.g, t),
            Mathf.LerpUnclamped(a.b, b.b, t),
            Mathf.LerpUnclamped(a.a, b.a, t)
        );
    }

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first int</param>
    /// <param name="b">The second int</param>
    /// <returns>The distance between the two ints</returns>
    public static float IntDist(int a, int b) => a - b;

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first float</param>
    /// <param name="b">The second float</param>
    /// <returns>The distance between the two floats</returns>
    public static float FloatDist(float a, float b) => a - b;

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first Vector2</param>
    /// <param name="b">The second Vector2</param>
    /// <returns>The distance between the two Vector2s</returns>
    public static float Vector2Dist(Vector2 a, Vector2 b) => Vector2.Distance(a, b);

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first Vector3</param>
    /// <param name="b">The second Vector3</param>
    /// <returns>The distance between the two Vector3s</returns>
    public static float Vector3Dist(Vector3 a, Vector3 b) => Vector3.Distance(a, b);

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first Vector4</param>
    /// <param name="b">The second Vector4</param>
    /// <returns>The distance between the two Vector4s</returns>
    public static float Vector4Dist(Vector4 a, Vector4 b) => Vector4.Distance(a, b);

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first Quaternion</param>
    /// <param name="b">The second Quaternion</param>
    /// <returns>The distance between the two Quaternions</returns>
    public static float QuaternionDist(Quaternion a, Quaternion b) => Vector3.Distance(a.eulerAngles, b.eulerAngles);

    /// <summary>
    /// Calculates and returns the distance between a and b
    /// </summary>
    /// <param name="a">The first Color</param>
    /// <param name="b">The second Color</param>
    /// <returns>The distance between the two Colors</returns>
    public static float ColorDist(Color a, Color b)
    {
        Vector4 i = new Vector4(a.r, a.g, a.b, a.a);
        Vector4 f = new Vector4(b.r, b.g, b.b, b.a);

        return Vector4.Distance(i, f);
    }
}