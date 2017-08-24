using UnityEngine;

namespace UnityUtilities
{
    [RequireComponent(typeof(Renderer))]
    public class RandomRendererColour : MonoBehaviour
    {
        [SerializeField]
        private float lerpSpeed = 0.1f;

        private float lerpIntensity;
        private Color lerpColour;

        private new Renderer renderer;

        private void Start()
        {
            renderer = GetComponent<Renderer>();

            lerpColour = RandomUtilities.Colour();
            lerpColour = new Color(Mathf.Clamp(0.3f, 0.8f, lerpColour.r), Mathf.Clamp(0.2f, 0.8f, lerpColour.g), Mathf.Clamp(0.3f, 0.8f, lerpColour.b));
        }

        private void Update()
        {
            if (lerpColour != renderer.material.color)
            {
                renderer.material.color = Color.Lerp(renderer.material.color, lerpColour, lerpIntensity);
            }
            else
            {
                lerpIntensity = 0;
                lerpColour = RandomUtilities.Colour();
            }

            lerpIntensity += lerpSpeed * Time.deltaTime;
        }
    }
}
