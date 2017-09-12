using UnityEngine;
using DigitalRuby.WeatherMaker;

namespace Fungus
{

    [CommandInfo("SmallWorld", 
        "WeatherSetup", 
        "Setup weather in the beginning")]	
    public class WeatherSetup : Command
    {
        [Tooltip("Weather Maker Prefab")]
        public GameObject weatherController;

        private WeatherMakerConfigurationScript weatherScript;

        [Range(0, 1)]
        [Tooltip("Volume level for IA-Music node")]
        [SerializeField]
        protected float volume = 1f;

        [Range(0, 30)]
        [Tooltip("Time to fade between current volume level and target volume level.")]
        [SerializeField]
        protected float fadeDuration = 1f;

        [Tooltip("Wait until the volume fade has completed before continuing.")]
        [SerializeField]
        protected bool waitUntilFinished = true;

        public bool snowFlag = false;
        public bool hailFlag = false;
        public bool sleedFlag = false;
        public bool sunFlag = false;
        public bool dayNightCycleFlag = false;
        public bool cloudsFlag = false;
        public bool fogFlag = false;

        #region Public members

        public override void OnEnter()
        {
            if (weatherController != null)
            {
                weatherScript = weatherController.GetComponent<WeatherMakerConfigurationScript>();
                Debug.Log("Load weather component successfully");

                //disable some un-use objects
                GameObject config = weatherController.transform.Find("ConfigurationCanvas").gameObject;
                Destroy(config);

                if (snowFlag == false)
                {
                    GameObject snow = weatherController.transform.Find("SnowPrefab").gameObject;
                    Destroy(snow);
                }

                if (hailFlag == false)
                {
                    GameObject hail = weatherController.transform.Find("HailPrefab").gameObject;
                    Destroy(hail);
                }

                if (sleedFlag == false)
                {
                    GameObject sleed = weatherController.transform.Find("SleetPrefab").gameObject;
                    Destroy(sleed);
                }

                if (sunFlag == false)
                {
                    GameObject sun = weatherController.transform.Find("Sun").gameObject;
                    Destroy(sun);
                }

                GameObject skySphere = weatherController.transform.Find("SkySphere").gameObject;
                Destroy(skySphere);

                if (dayNightCycleFlag == false)
                {
                    GameObject dayNightCycle = weatherController.transform.Find("DayNightCycle").gameObject;
                    Destroy(dayNightCycle);
                }

                if (cloudsFlag == false)
                {
                    GameObject clouds = weatherController.transform.Find("Clouds").gameObject;
                    Destroy(clouds);
                }

                if (fogFlag == false)
                {
                    GameObject fog = weatherController.transform.Find("Fog").gameObject;
                    Destroy(fog);
                }

                //script.Camera = Camera.main;

            }
            else
            {
                Debug.Log("Could not load weather component");
            }

            Continue();
        }

        public override string GetSummary()
        {
            return "Initiating weather system.";
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 221, 169, 255);
        }
        #endregion
    }

}