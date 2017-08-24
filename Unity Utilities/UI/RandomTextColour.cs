using UnityEngine;
using UnityEngine.UI;

namespace UnityUtilities.UI
{
    [RequireComponent(typeof(Text))]
    public class RandomTextColour : MonoBehaviour
    {
        [SerializeField]
        private float lerpSpeed = 0.1f;

        [SerializeField]
        private Color shadowMultiplier = new Color(0.1f, 0.1f, 0.1f, 1);

        private float lerpIntensity;
        private Color lerpColour;

        private Text textComponent;
        private Shadow shadow;

        private void Start()
        {
            textComponent = GetComponent<Text>();
            shadow = GetComponent<Shadow>();

            if (shadow)
            {
                shadow.effectColor = textComponent.color * shadowMultiplier;
            }

            lerpColour = RandomUtilities.Colour();
            lerpColour = new Color(Mathf.Clamp(0.3f, 0.8f, lerpColour.r), Mathf.Clamp(0.2f, 0.8f, lerpColour.g), Mathf.Clamp(0.3f, 0.8f, lerpColour.b));
        }

        private void Update()
        {
            if (lerpColour != textComponent.color)
            {
                textComponent.color = Color.Lerp(textComponent.color, lerpColour, lerpIntensity);
                if (shadow)
                {
                    shadow.effectColor = Color.Lerp(shadow.effectColor, lerpColour * shadowMultiplier, lerpIntensity);
                }
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
