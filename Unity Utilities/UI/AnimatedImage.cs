using UnityEngine;
using UnityEngine.UI;

namespace UnityUtilities.UI
{
    [RequireComponent(typeof(Image))]
    public class AnimatedImage : MonoBehaviour
    {
        [SerializeField]
        private float framesPerSecond = 10f;
        [SerializeField]
        private Sprite[] frames;

        private int frameIndex;

        private void Start()
        {
            NextFrame();
            InvokeRepeating("NextFrame", 1 / framesPerSecond, 1 / framesPerSecond);
        }

        private void NextFrame()
        {
            if (frames == null) return;

            GetComponent<Image>().sprite = frames[frameIndex];
            frameIndex = (frameIndex + 1) % frames.Length;
        }
    }
}
