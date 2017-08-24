using UnityEngine;

namespace UnityUtilities
{
    public class CornerAlignment : MonoBehaviour
    {
        [SerializeField]
        private Corner corner;
        [SerializeField]
        private Vector3 offset;
        private Vector3 originalPosition;

        private void Start()
        {
            originalPosition = transform.position;
        }

        private void Update()
        {
            switch (corner)
            {
                case Corner.TopLeft:
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)) + offset;
                    break;
                case Corner.TopRight:
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)) + offset;
                    break;
                case Corner.BottomLeft:
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)) + offset;
                    break;
                case Corner.BottomRight:
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)) + offset;
                    break;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, originalPosition.z);
        }
    }
}

