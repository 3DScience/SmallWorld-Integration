using UnityEngine;
using UnityEditor;

namespace Fungus.EditorUtils
{

	[CustomEditor (typeof(PlayIAMusic))]
	public class PlayIAMusicEditor : CommandEditor 
	{
        protected SerializedProperty iaMusicNodeProp;
		protected SerializedProperty loopProp;
        protected SerializedProperty fadeDuration;

        protected virtual void OnEnable()
		{
            iaMusicNodeProp = serializedObject.FindProperty("iaMusicNode");
			loopProp = serializedObject.FindProperty("loop");
            fadeDuration = serializedObject.FindProperty("fadeDuration");
        }

		public override void DrawCommandGUI()
		{
			serializedObject.Update();

            InMusicGroup iaMusicNode = target as InMusicGroup;

            EditorGUILayout.PropertyField(iaMusicNodeProp);
			EditorGUILayout.PropertyField(loopProp);
            EditorGUILayout.PropertyField(fadeDuration);

            serializedObject.ApplyModifiedProperties();
		}
	}

}