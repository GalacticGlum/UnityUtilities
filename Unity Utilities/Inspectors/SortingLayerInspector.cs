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

        public void Apply(string sortingLayerName, int order)
        {
            if (Renderer == null) return;
            Renderer.sortingLayerName = sortingLayerName;
            Renderer.sortingOrder = order;
        }
    }
}
