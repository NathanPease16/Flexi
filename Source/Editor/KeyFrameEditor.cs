using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Unity.VisualScripting;

public enum CurveType
{
    Custom,
    Linear,
    Quadratic,
    Cubic,
    Bouncing,
    Overshoot,
    Recovery,
    EaseIn,
    EaseOut,
    EaseInOut,
}

[CustomPropertyDrawer(typeof(FlexiKeyFrame<>))]
public class KeyFrameEditor : PropertyDrawer
{
    private CurveType _curveMode;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float totalHeight = EditorGUIUtility.singleLineHeight;

        if (property.isExpanded)
        {
            totalHeight += EditorGUIUtility.singleLineHeight;

            foreach (SerializedProperty serializedProperty in GetAllProperties(property))
            {
                if (serializedProperty.displayName.StartsWith("Element"))
                    continue;

                if (serializedProperty.name == "_curve")
                {
                    totalHeight += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    if (_curveMode != CurveType.Custom)
                        continue;
                }
                totalHeight += EditorGUI.GetPropertyHeight(serializedProperty);
            }
        }

        return totalHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        GUIStyle style = new GUIStyle(EditorStyles.foldout) { fontStyle = FontStyle.Bold };
        position.height = EditorGUIUtility.singleLineHeight;
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label, style);
        
        if (!property.isExpanded)
            return;
        
        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        foreach (SerializedProperty serializedProperty in GetAllProperties(property))
        {
            if (serializedProperty.displayName.StartsWith("Element"))
                continue;

            if (serializedProperty.name == "_curve")
            {
                string path = property.propertyPath + property.serializedObject.targetObject.GetInstanceID();
                var curve = (CurveType)EditorPrefs.GetInt(path, (int)CurveType.Custom);
                
                _curveMode = (CurveType)EditorGUI.EnumPopup(position, "Curve Type", curve);
                EditorPrefs.SetInt(path, (int)_curveMode);

                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                if (_curveMode != CurveType.Custom)
                {
                    if (_curveMode == CurveType.Linear)
                        serializedProperty.animationCurveValue = FlexiCurves.linear;
                    else if (_curveMode == CurveType.Quadratic)
                        serializedProperty.animationCurveValue = FlexiCurves.quadratic;
                    else if (_curveMode == CurveType.Cubic)
                        serializedProperty.animationCurveValue = FlexiCurves.cubic;
                    else if (_curveMode == CurveType.Bouncing)
                        serializedProperty.animationCurveValue = FlexiCurves.bouncing;
                    else if (_curveMode == CurveType.Overshoot)
                        serializedProperty.animationCurveValue = FlexiCurves.overshoot;
                    else if (_curveMode == CurveType.Recovery)
                        serializedProperty.animationCurveValue = FlexiCurves.recovery;
                    else if (_curveMode == CurveType.EaseIn)
                        serializedProperty.animationCurveValue = FlexiCurves.easeIn;
                    else if (_curveMode == CurveType.EaseOut)
                        serializedProperty.animationCurveValue = FlexiCurves.easeOut;
                    else if (_curveMode == CurveType.EaseInOut)
                        serializedProperty.animationCurveValue = FlexiCurves.easeInOut;
                    continue;
                }
            }

            EditorGUI.PropertyField(position, serializedProperty);
            position.y += EditorGUI.GetPropertyHeight(serializedProperty) + EditorGUIUtility.standardVerticalSpacing;
        }

        EditorGUI.EndProperty();
    }

    public List<SerializedProperty> GetAllProperties(SerializedProperty property)
    {
        List<SerializedProperty> properties = new List<SerializedProperty>();
        SerializedProperty copy = property.Copy();

        if (copy.Next(true))
        {
            do 
                properties.Add(copy.Copy());
            while (copy.Next(false));
        }
        
        return properties;
    }
}
