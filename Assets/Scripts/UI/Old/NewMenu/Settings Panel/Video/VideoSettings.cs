using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ElementStudio.Pivotal.Menu
{
    public class VideoSettings : MonoBehaviour
    {
        [Header("Resolution")]
        public TMP_Dropdown resolutionDropdown;
        public Toggle fullscreenToggle;
        public Toggle exclusiveFullscreenToggle;
        public Toggle vsyncToggle;
        Resolution[] availableResolutions;
        int currentlySelectedResolution;

        void OnEnable()
        {
            SetupResolutions();
        }

        void SetupResolutions()
        {
            //Get available resolutions
            availableResolutions = Screen.resolutions;
            int currentResolution = Manager.PivotalManager.instance.settings.video.resolutionIndex;
            /*int currentResolution = System.Array.IndexOf(availableResolutions, Screen.currentResolution);
            if (PlayerPrefs.HasKey("Resolution"))
            {
                currentResolution = PlayerPrefs.GetInt("Resolution", Screen.resolutions.Length - 1);
            } */

            //Loop through our current resolutions in order to add them to our dropdown
            for (int i = 0; i < availableResolutions.Length; i++)
            {
                resolutionDropdown.options[i].text = ResolutionToString(availableResolutions[i]);
                resolutionDropdown.value = i;
                resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionDropdown.options[i].text));
            }
            //Remove an errant resolution that gets added.
            resolutionDropdown.options.RemoveAt(resolutionDropdown.options.Count - 1);
            //Change the resolution in the settings once it's selected
            resolutionDropdown.onValueChanged.AddListener(delegate
            {
                Manager.PivotalManager.instance.settings.video.resolutionIndex = resolutionDropdown.value;
            });
            resolutionDropdown.value = currentResolution;

            //Fullscreen
            fullscreenToggle.onValueChanged.AddListener(delegate
            {
                Manager.PivotalManager.instance.settings.video.useFullscreen = fullscreenToggle.isOn;
            });
            fullscreenToggle.isOn = Manager.PivotalManager.instance.settings.video.useFullscreen;

            //Exclusive fullscreen
            exclusiveFullscreenToggle.onValueChanged.AddListener(delegate
            {
                Manager.PivotalManager.instance.settings.video.useExclusiveFullscreen = exclusiveFullscreenToggle.isOn;
            });
            exclusiveFullscreenToggle.isOn = Manager.PivotalManager.instance.settings.video.useExclusiveFullscreen;

            //Vertical sync
            vsyncToggle.onValueChanged.AddListener(delegate
            {
                Manager.PivotalManager.instance.settings.video.syncEveryFrame = exclusiveFullscreenToggle.isOn;
            });
            vsyncToggle.isOn = Manager.PivotalManager.instance.settings.video.syncEveryFrame;
        }

        string ResolutionToString(Resolution r)
        {
            return string.Format("{0}x{1}@{2}Hz", r.width, r.height, r.refreshRate);
        }

        public void ApplySettings()
        {
            Manager.VideoSettings.ApplySettings();
        }
    }
}