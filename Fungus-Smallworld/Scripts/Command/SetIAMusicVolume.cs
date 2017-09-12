using UnityEngine;
using InAudioSystem;

namespace Fungus
{

    [CommandInfo("SmallWorld", 
        "SetIAMusicVolume", 
        "Set volume for an IA-Music node")]	
    public class SetIAMusicVolume : Command
    {
        [Tooltip("Node in IA-Music that is being controlled.")]
        public InMusicGroup iaMusicNode;

        [Range(0, 1)]
        [Tooltip("Volume level for IA-Music node")]
        [SerializeField]
        protected float volume = 1f;

        [Range(0, 30)]
        [Tooltip("Time to fade between current volume level and target volume level.")]
        [SerializeField]
        protected float fadeDuration = 1f;

        [Tooltip("Not implemented yet. Wait until the volume fade has completed before continuing.")]
        [SerializeField]
        protected bool waitUntilFinished = true;

        #region Public members

        public override void OnEnter()
        {
            if (iaMusicNode != null)
            {
                InAudio.Music.FadeVolume(iaMusicNode, volume, fadeDuration);
            }
            
            Continue();
        }

        public override string GetSummary()
        {
            return "Set to " + volume + " over " + fadeDuration + " seconds.";
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 221, 169, 255);
        }
        #endregion
    }

}