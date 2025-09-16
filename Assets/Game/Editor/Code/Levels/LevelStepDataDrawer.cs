using UnityEditor;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Levels.Editor
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Property drawer for LevelStepData that displays different fields based on the selected step type.
    /// Changelog:       
    /// </summary>
    [CustomPropertyDrawer(typeof(LevelStepData))]
    public class LevelStepDataDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty item, GUIContent label)
        {
            SerializedProperty enabledProp = item.FindPropertyRelative("enabled");
            SerializedProperty timeBeforeProp = item.FindPropertyRelative("timeBefore");
            SerializedProperty levelStepTypeProp = item.FindPropertyRelative("type");
            LevelStepType t = (LevelStepType) levelStepTypeProp.intValue;

            GUI.Box(position, GUIContent.none, EditorStyles.helpBox);
            position.x += 2;
            position.y += 2;
            position.width -= 4;
            position.height -= 4;
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float labelWidth = EditorGUIUtility.labelWidth;

            EditorGUIUtility.labelWidth = 80;
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width * 0.5f, lineHeight), enabledProp,
                true);
            EditorGUI.PropertyField(
                new Rect(position.x + (position.width * 0.5f), position.y, position.width * 0.5f, lineHeight),
                timeBeforeProp, true);
            EditorGUI.PropertyField(new Rect(position.x, position.y + (lineHeight), position.width, lineHeight),
                levelStepTypeProp, true);
            if (t == LevelStepType.WAVE)
            {
                SerializedProperty waveCountProp = item.FindPropertyRelative("waveCount");
                SerializedProperty enemyIdProp = item.FindPropertyRelative("enemyId");
                SerializedProperty betweenTimeProp = item.FindPropertyRelative("betweenTime");
                SerializedProperty spawnOffsetProp = item.FindPropertyRelative("spawnOffset");
                EditorGUI.PropertyField(
                    new Rect(position.x, position.y + (lineHeight * 2), position.width * 0.5f, lineHeight),
                    waveCountProp,
                    true);
                EditorGUI.PropertyField(
                    new Rect(position.x + (position.width * 0.5f), position.y + (lineHeight * 2), position.width * 0.5f,
                        lineHeight), enemyIdProp, true);
                EditorGUIUtility.labelWidth = 90;
                EditorGUI.PropertyField(
                    new Rect(position.x, position.y + (lineHeight * 3), position.width * 0.4f, lineHeight),
                    betweenTimeProp,
                    true);
                EditorGUIUtility.labelWidth = 100;
                EditorGUI.PropertyField(
                    new Rect(position.x + (position.width * 0.45f), position.y + (lineHeight * 3),
                        position.width - (position.width * 0.4f), lineHeight), spawnOffsetProp, true);
            }
            else if (t == LevelStepType.SHOW_TEXT)
            {
                SerializedProperty textProp = item.FindPropertyRelative("text");
                float h = EditorGUI.GetPropertyHeight(textProp);
                EditorGUI.PropertyField(new Rect(position.x, position.y + (lineHeight * 2), position.width, h),
                    textProp, true);

            }

            EditorGUIUtility.labelWidth = labelWidth;
        }

        public override float GetPropertyHeight(SerializedProperty item, GUIContent label)
        {
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float totalHeight = (lineHeight * 2) + 8;
            SerializedProperty levelStepTypeProp = item.FindPropertyRelative("type");
            LevelStepType t = (LevelStepType) levelStepTypeProp.intValue;
            if (t == LevelStepType.WAVE)
            {
                totalHeight += (lineHeight * 3);
            }
            else if (t == LevelStepType.SHOW_TEXT)
            {
                SerializedProperty textProp = item.FindPropertyRelative("text");
                totalHeight += EditorGUI.GetPropertyHeight(textProp);
            }

            return totalHeight;
        }
    }
}