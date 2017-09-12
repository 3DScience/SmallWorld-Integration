using UnityEngine;

namespace Fungus
{

    [CommandInfo("SmallWorld", 
        "PlayIAMusic", 
        "Play an IA-Music node")]	
    public class PlayIAMusic : Command
    {
        [Tooltip("Node in IA-Music that is played")]
        [SerializeField]
        public InMusicGroup iaMusicNode;

        [Tooltip("Not implemented yet")]
        [SerializeField]
        public bool loop;

        [Range(0, 30)]
        [Tooltip("Time to fade in")]
        [SerializeField]
        protected float fadeDuration = 1f;

        public override void OnEnter()
        {
            if (iaMusicNode != null)
            {
                InAudio.Music.PlayWithFadeIn(iaMusicNode, fadeDuration);
            }
            Continue();
        }

        public override string GetSummary()
        {
            if (iaMusicNode == null)
            {
                return "Error: No IA-Music node selected";
            }
            else return iaMusicNode.GetName + " (fade in  over " + fadeDuration + " seconds)";
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 221, 169, 255);
        }
    }

}