using UnityEngine;

namespace UnityUtilities
{
    public static class UnityExtensions
    {
        public static Vector2 WorldToCanvas(this Canvas canvas, Vector3 worldPosition, Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }

            Vector2 viewportPosition = camera.WorldToViewportPoint(worldPosition);
            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();

            return new Vector2(viewportPosition.x * canvasRectTransform.sizeDelta.x - canvasRectTransform.sizeDelta.x * 0.5f,
                               viewportPosition.y * canvasRectTransform.sizeDelta.y - canvasRectTransform.sizeDelta.y * 0.5f);
        }
    }
}
