using UnityEngine;

namespace UnityUtilities
{
    public static class UnityConvert
    {
        private const float RGB_VALUE = 255.0f;

        public static Color Color(float red, float green, float blue) => Color(red, green, blue, 255);
        public static Color Color(float red, float green, float blue, float alpha) => 
            new Color(red / RGB_VALUE, green / RGB_VALUE, blue / RGB_VALUE, alpha / RGB_VALUE);
    }
}
