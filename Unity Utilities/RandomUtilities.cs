using UnityEngine;

namespace UnityUtilities
{
    public static class RandomUtilities
    {
        public static Color Colour() => new Color(Random.value, Random.value, Random.value);
    }
}
