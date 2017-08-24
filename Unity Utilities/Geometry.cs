using UnityEngine;

namespace UnityUtilities
{
    public class Geometry
    {
        public static Vector3 RandomPointOnScreen() => RandomPointOnScreen(0);

        public static Vector3 RandomPointOnScreen(float padding)
            => RandomPointOnScreen(padding, padding, padding, padding);

        public static Vector3 RandomPointOnScreen(float paddingLeft, float paddingRight, float paddingTop, float paddingBottom)
            => RandomPointOnScreen(new Vector4(paddingLeft, paddingRight, paddingTop, paddingBottom));

        public static Vector3 RandomPointOnScreen(Vector4 padding) => 
            Camera.main.ScreenToWorldPoint(new Vector3(
                Random.Range(padding.x, Screen.width - padding.y), 
                Random.Range(padding.z, Screen.height - padding.w),
                Camera.main.farClipPlane / 2));
    }
}
