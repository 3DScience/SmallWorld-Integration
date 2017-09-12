using UnityEngine;

namespace Fungus
{

    [CommandInfo("SmallWorld", 
        "PlayIAAudio", 
        "Play an IA-Audio node")]	
    public class PlayIAAudio : Command
    {
        [Tooltip("Node in IA-Audio that is played")]
        public InAudioNode iaAudioNode;

        [Tooltip("Not implemented yet")]
        public bool loop;
        [Tooltip("Not implemented yet")]
        public bool waitUntilFinished = true;

        public override void OnEnter()
        {
            if (iaAudioNode != null && gameObject != null)
                InAudio.Play(gameObject, iaAudioNode);
            Continue();
        }

        public override string GetSummary()
        {
            if (iaAudioNode == null)
            {
                return "Error: No IA-Audio node selected";
            }
            else return iaAudioNode.Name;
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 221, 169, 255);
        }
    }

}