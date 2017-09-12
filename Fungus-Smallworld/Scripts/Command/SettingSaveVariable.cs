using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Save an Boolean, Integer, Float or String variable to persistent storage using a string key.
    /// The value can be loaded again later using the Load Variable command. You can also 
    /// use the Set Save Profile command to manage separate save profiles for multiple players.
    /// </summary>
    /// 
    public enum SWSetting
    {
        /// <summary>
        /// None at initial.
        /// </summary>
        none,
        /// <summary>
        /// Autoplay: 1 ON; 1 OFF
        /// </summary>
        autoplay,
        /// <summary>
        /// Narrator's voice: 1 ON; 0 OFF
        /// </summary>
        narrator,
        /// <summary>
        /// Music: 1 On; 0 OFF.
        /// </summary>
        music,
        /// <summary>
        /// Language: 1 for English and 0 for Native language.
        /// </summary>
        language
    }

    [CommandInfo("SmallWorld", 
                 "Save setting variable", 
                 "Save an Boolean, Integer, Float or String variable to persistent storage using a string key. ")]
    [AddComponentMenu("")]
    public class SettingSaveVariable : Command
    {
        [Tooltip("The type of loop to apply once the animation has completed")]
        [SerializeField]
        public SWSetting settingVar = SWSetting.none;

        [Tooltip("Name to save/restore. Can't be changed!")]
        [SerializeField]
        public string settingKey = "";

        [Tooltip("On/Off features")]
        [SerializeField] protected bool booleanData;

        #region Public members

        public override void OnEnter()
        {
            if (settingVar == SWSetting.none)
            {
                Continue();
                return;
            }
            
            PlayerPrefs.SetInt(settingKey, booleanData ? 1 : 0);
            Debug.Log(settingKey + " is changed to " + booleanData);
            Continue();
        }
        
        public override string GetSummary()
        {
            if (settingVar == SWSetting.none)
            {
                return "Nothing to be saved";
            }
            
            return "Saving " + settingVar.ToString() + " to " + booleanData;
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        #endregion
    }    
}