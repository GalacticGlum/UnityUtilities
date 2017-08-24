using UnityEngine;

namespace UnityUtilities.Effects
{
    [RequireComponent(typeof(Projector))]
    public class AmimatedProjector : MonoBehaviour
    {
        [SerializeField]
        private float framesPerSecond = 30.0f;
        [SerializeField]
        private Texture2D[] frames;

        private int frameIndex;
        private Projector projector;

        private void Start()
        {
            projector = GetComponent<Projector>();
            NextFrame();
            InvokeRepeating("NextFrame", 1 / framesPerSecond, 1 / framesPerSecond);
        }

        private void NextFrame()
        {
            projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
            frameIndex = (frameIndex + 1) % frames.Length;
        }
    }
}
