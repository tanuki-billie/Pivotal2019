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
        Resolution[] availableResolutions;
        int currentlySelectedResolution;

        void Awake()
        {
            SetupResolutions();
        }

        void SetupResolutions()
        {
            availableResolutions = Screen.resolutions;
            int currentResolution = System.Array.IndexOf(availableResolutions, Screen.currentResolution);
            if (PlayerPrefs.HasKey("Resolution"))
            {
                currentResolution = PlayerPrefs.GetInt("Resolution", Screen.resolutions.Length - 1);
            }

            for (int i = 0; i < availableResolutions.Length; i++)
            {
                resolutionDropdown.options[i].text = ResolutionToString(availableResolutions[i]);
                resolutionDropdown.value = i;
                resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionDropdown.options[i].text));
            }
            resolutionDropdown.options.RemoveAt(resolutionDropdown.options.Count - 1);
            resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(availableResolutions[resolutionDropdown.value], true, resolutionDropdown.value); });
            resolutionDropdown.value = currentResolution;

            //Fullscreen
            fullscreenToggle.onValueChanged.AddListener(delegate { Screen.fullScreen = fullscreenToggle.isOn; });
            fullscreenToggle.isOn = Screen.fullScreen;
        }

        string ResolutionToString(Resolution r)
        {
            return string.Format("{0}x{1}@{2}Hz", r.width, r.height, r.refreshRate);
        }

        void SetFullscreen(bool value)
        {
            Screen.fullScreen = value;
        }

        void SetResolution(Resolution r, bool saveRes = false, int res = 0)
        {
            Screen.SetResolution(r.width, r.height, Screen.fullScreen, r.refreshRate);
            if (saveRes)
            {
                PlayerPrefs.SetInt("Resolution", res);
            }
        }
    }
}