﻿using UnityEditor;
using UnityEngine;

namespace UnityUtilities.Editor
{
    [CustomPropertyDrawer(typeof(ReadonlyPropertyAttribute))]
    public class ReadonlyPropertyAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => EditorGUI.GetPropertyHeight(property, label, true);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}
