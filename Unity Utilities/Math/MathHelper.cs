using UnityEngine;

namespace UnityUtilities.Math
{
    public static class MathHelper
    {
        public const float Tau = Mathf.PI * 2.0f;

        /// <summary>
        /// If a - b is less than the double.Epsilon value then they are treated as equal.
        /// </summary>
        /// <returns>true if a - b &lt; tolerance else false.</returns>
        public static bool AreEqual(this double a, double b)
        {
            if (a.CompareTo(b) == 0)
            {
                return true;
            }

            return System.Math.Abs(a - b) < double.Epsilon;
        }

        /// <summary>
        /// If value is lower than the double.Epsilon value then value is treated as zero.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if value is lower than tolerance value.</returns>
        public static bool IsZero(this double value)
        {
            return System.Math.Abs(value) < double.Epsilon;
        }

        /// <summary>
        /// If a - b is less than the double.Epsilon value then they are treated as equal.
        /// </summary>
        /// <returns>true if a - b &lt; tolerance else false.</returns>
        public static bool AreEqual(this float a, float b)
        {
            if (a.CompareTo(b) == 0)
            {
                return true;
            }

            return System.Math.Abs(a - b) < double.Epsilon;
        }

        /// <summary>
        /// If value is lower than the double.Epsilon value then value is treated as zero.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if value is lower than tolerance value.</returns>
        public static bool IsZero(this float value)
        {
            return System.Math.Abs(value) < double.Epsilon;
        }
    }
}
