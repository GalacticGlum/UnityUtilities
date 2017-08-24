using UnityEngine;

namespace UnityUtilities.Inspectors
{
    [RequireComponent(typeof(Renderer))]
    [ExecuteInEditMode]
    public class SortingLayerInspector : MonoBehaviour
    {
        public Renderer Renderer { get; private set; }

        private void Start()
        {
            Renderer = GetComponent<Renderer>();
        }

        public void ApplySortingLayer(string sortingLayerName)
        {
            if (Renderer != null)
            {
                Renderer.sortingLayerName = sortingLayerName;
            }
        }
    }
}
