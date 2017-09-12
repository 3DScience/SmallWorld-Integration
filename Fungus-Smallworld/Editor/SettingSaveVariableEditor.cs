// This code support to save Setting variable for SmallWorld
using UnityEditor;

namespace Fungus.EditorUtils
{

    [CustomEditor (typeof(SettingSaveVariable))]
    public class SettingSaveVariableEditor : CommandEditor 
    {
        protected SerializedProperty settingVarProp;
        protected SerializedProperty settingKeyProp;
        protected SerializedProperty booleanDataProp;

        string settingKey;

        protected virtual void OnEnable()
        {
            if (NullTargetCheck()) // Check for an orphaned editor instance
                return;

            settingVarProp = serializedObject.FindProperty("settingVar");
            settingKeyProp = serializedObject.FindProperty("settingKey");
            booleanDataProp = serializedObject.FindProperty("booleanData");
        }

        public override void DrawCommandGUI()
        {
            serializedObject.Update();

            SettingSaveVariable t = target as SettingSaveVariable;

            EditorGUILayout.PropertyField(settingVarProp);

            switch (t.settingVar) {
                case SWSetting.none:
                    serializedObject.ApplyModifiedProperties();
                    return;
                case SWSetting.autoplay:
                    settingKey = "setting_autoplay";
                    break;
                case SWSetting.narrator:
                    settingKey = "setting_narrator";
                    break;
                case SWSetting.music:
                    settingKey = "setting_music";
                    break;
                case SWSetting.language:
                    settingKey = "setting_language";
                    break;
            }

            EditorGUILayout.TextField("Name", settingKey);
            t.settingKey = settingKey;
            EditorGUILayout.PropertyField(booleanDataProp);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
