using UnityEngine;
using DigitalRuby.WeatherMaker;

namespace Fungus
{

    [CommandInfo("SmallWorld", 
        "WeatherChange", 
        "Change weather as desire")]	
    public class WeatherChange : Command
    {
        [Tooltip("Weather Maker Prefab")]
        public GameObject weatherController;

        private WeatherMakerConfigurationScript weatherScript;

        [Range(0, 1)]
        [Tooltip("Snow intensity")]
        [SerializeField]
        protected float snowVolume = 1f;

        [Range(0, 3)]
        [Tooltip("Time to fade between current volume level and target volume level.")]
        [SerializeField]
        protected float snowFadeDuration = 1f;

        #region Public members

        public override void OnEnter()
        {
            weatherScript = weatherController.GetComponent<WeatherMakerConfigurationScript>();

            if (weatherScript != null)
            {
                weatherScript.SnowToggleChanged(true);
                weatherScript.IntensitySliderChanged(snowVolume);
            }

            Continue();
        }

        public override string GetSummary()
        {
            return "Set snow intensity to " + snowVolume + " over " + snowFadeDuration + " seconds.";
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 221, 169, 255);
        }
        #endregion
    }

}