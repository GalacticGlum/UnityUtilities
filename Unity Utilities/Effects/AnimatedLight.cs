using UnityEngine;

namespace UnityUtilities.Effects
{
    [RequireComponent(typeof(Light))]
    public class AnimatedLight : MonoBehaviour
    {
        [SerializeField]
        private float framesPerSecond = 30.0f;
        [SerializeField]
        private Texture2D[] frames;

        private int frameIndex;
        private Light light;

        private void Start()
        {
            light = GetComponent<Light>();
            NextFrame();
            InvokeRepeating("NextFrame", 1 / framesPerSecond, 1 / framesPerSecond);
        }

        private void NextFrame()
        {
            light.cookie = frames[frameIndex];
            frameIndex = (frameIndex + 1) % frames.Length;
        }
    }
}
