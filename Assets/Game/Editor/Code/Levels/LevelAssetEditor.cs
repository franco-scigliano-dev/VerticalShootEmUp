using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;

namespace com.fscigliano.VerticalShootEmUp.Levels.Editor
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Custom editor for LevelAsset with a reorderable list interface for managing level data.
    /// Changelog:       
    /// </summary>
    [CustomEditor(typeof(LevelAsset))]
    public class LevelAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty listProp;
        private ReorderableList list;
        private List<float> heights;
        private SerializedProperty gameModeProp;
        private void OnEnable()
        {
            gameModeProp = serializedObject.FindProperty("_gameMode");
            
            listProp = serializedObject.FindProperty("_levelDatas");
            
            list = new ReorderableList(serializedObject, 
                listProp, true, true, true, true);
            list.drawHeaderCallback = rect => {
                EditorGUI.LabelField (rect, "Level Data"); 
            };
            list.drawElementCallback += (position, index, active, focused) =>
            {
                SerializedProperty item = listProp.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(position, item, true);
            };
            list.elementHeightCallback += index =>
            {
                SerializedProperty item = listProp.GetArrayElementAtIndex(index);
                return EditorGUI.GetPropertyHeight(item);
            };
            
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            GameMode m = (GameMode)gameModeProp.intValue;
            EditorGUILayout.PropertyField(gameModeProp, true);
            if (m == GameMode.TIME)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_time"), true);
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_backgroundPrefab"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_cameraFillColor"), true);
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}