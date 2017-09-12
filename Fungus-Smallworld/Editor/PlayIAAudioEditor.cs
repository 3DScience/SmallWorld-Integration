using UnityEngine;
using UnityEditor;

namespace Fungus.EditorUtils
{

	[CustomEditor (typeof(PlayIAAudio))]
	public class PlayInAudioEditor : CommandEditor 
	{
        protected SerializedProperty iaAudioNodeProp;
		protected SerializedProperty loopProp;
		protected SerializedProperty waitUntilFinishedProp;

		protected virtual void OnEnable()
		{
            iaAudioNodeProp = serializedObject.FindProperty("iaAudioNode");
			loopProp = serializedObject.FindProperty("loop");
			waitUntilFinishedProp = serializedObject.FindProperty("waitUntilFinished");
		}

		public override void DrawCommandGUI()
		{
			serializedObject.Update();

            //PlayIAAudio playIAAudio = target as PlayIAAudio;

            EditorGUILayout.PropertyField(iaAudioNodeProp);
			EditorGUILayout.PropertyField(loopProp);
			EditorGUILayout.PropertyField(waitUntilFinishedProp);

			serializedObject.ApplyModifiedProperties();
		}
	}

}