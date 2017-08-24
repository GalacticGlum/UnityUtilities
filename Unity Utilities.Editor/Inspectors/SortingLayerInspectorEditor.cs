using System;
using System.Reflection;

using UnityEditor;
using UnityEditorInternal;

using UnityUtilities.Inspectors;

namespace UnityUtilities.Editor.Inspectors
{
    [CustomEditor(typeof(SortingLayerInspector))]
    public class SortingLayerInspectorEditor : UnityEditor.Editor
    {
        private int sortingLayerIndex;

        public override void OnInspectorGUI()
        {
            SortingLayerInspector inspector = (SortingLayerInspector)target;
            string[] sortingLayers = GetSortingLayerNames();

            int startIndex = Array.IndexOf(sortingLayers, inspector.Renderer.sortingLayerName);
            sortingLayerIndex = EditorGUILayout.Popup("Sorting Layer", startIndex, sortingLayers);

            inspector.ApplySortingLayer(sortingLayers[sortingLayerIndex]);
        }

        private static string[] GetSortingLayerNames()
        {
            Type internalEditorUtilityType = typeof(InternalEditorUtility);
            PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
            return (string[])sortingLayersProperty.GetValue(null, new object[0]);
        }
    }
}
