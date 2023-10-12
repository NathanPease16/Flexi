using UnityEngine;

public static class FlexiOperations
{
    public static int IntOp(int a, int b, float t) => (int)Mathf.LerpUnclamped(a, b, t);


    public static float FloatOp(float a, float b, float t) => Mathf.LerpUnclamped(a, b, t);

    public static Vector2 Vector2Op(Vector2 a, Vector2 b, float t)
    {
        return new Vector2
        (
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t)
        );
    }

    public static Vector3 Vector3Op(Vector3 a, Vector3 b, float t)
    {
        return new Vector3
        (
            Mathf.LerpUnclamped(a.x, b.x, t),
            Mathf.LerpUnclamped(a.y, b.y, t),
            Mathf.LerpUnclamped(a.z, b.z, t)
        );
    }

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

    public static Quaternion QuaternionOp(Quaternion a, Quaternion b, float t)
    {
        Vector3 opEuler = Vector3Op(a.eulerAngles, b.eulerAngles, t);

        return Quaternion.Euler(opEuler.x, opEuler.y, opEuler.z);
    }

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

    public static float IntDist(int a, int b) => a - b;

    public static float FloatDist(float a, float b) => a - b;

    public static float Vector2Dist(Vector2 a, Vector2 b) => Vector2.Distance(a, b);

    public static float Vector3Dist(Vector3 a, Vector3 b) => Vector3.Distance(a, b);

    public static float Vector4Dist(Vector4 a, Vector4 b) => Vector4.Distance(a, b);

    public static float QuaternionDist(Quaternion a, Quaternion b) => Vector3.Distance(a.eulerAngles, b.eulerAngles);

    public static float ColorDist(Color a, Color b)
    {
        Vector4 i = new Vector4(a.r, a.g, a.b, a.a);
        Vector4 f = new Vector4(b.r, b.g, b.b, b.a);

        return Vector4.Distance(i, f);
    }
}