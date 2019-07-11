using System.IO;
using UnityEngine;

namespace ElementStudio.Pivotal.Manager
{
    [System.Serializable]
    public class PivotalSettings
    {
        //Variables for all of our separate settings files. This includes video, audio, and game settings.
        public VideoSettings video;
        public AudioSettings audio;
        public GameSettings game;
        const string fileName = "settings.json";

        //Attempts to load settings from file. If this fails, then a new settings file is created.
        public void Load()
        {
            Debug.Log("Loading Pivotal settings");
            string path = Path.Combine(Application.persistentDataPath, fileName);
            string contents;
            try
            {
                contents = File.ReadAllText(path);
                if (contents == string.Empty)
                {
                    Initialize();
                    return;
                }
                PivotalSettings newFile = JsonUtility.FromJson<PivotalSettings>(contents);
                video = newFile.video;
                audio = newFile.audio;
                game = newFile.game;
            }
            catch (System.Exception e)
            {
                Initialize();
            }
            VideoSettings.ApplySettings();
        }

        //Function to create settings file.
        public void Initialize()
        {
            video = new VideoSettings(true);
            audio = new AudioSettings();
            game = new GameSettings();
            Save();
        }

        //Saves settings to disk.
        public void Save()
        {
            string contents = JsonUtility.ToJson(this, true);
            string path = Path.Combine(Application.persistentDataPath, fileName);
            File.WriteAllText(path, contents);
        }
    }

    [System.Serializable]
    public class VideoSettings
    {
        public int resolutionIndex;
        public bool useFullscreen;
        public bool useExclusiveFullscreen;
        public bool syncEveryFrame;
        public int antiAliasingIndex;
        public bool usePostProcessing;

        public VideoSettings(bool playing = false)
        {
            //Set default settings
            if (playing)
            {
                resolutionIndex = Screen.resolutions.Length - 1;
                useFullscreen = Screen.fullScreen;
            }
            else
            {
                resolutionIndex = 0;
                useFullscreen = false;
            }
            useExclusiveFullscreen = true;
            syncEveryFrame = true;
            antiAliasingIndex = 4;
            usePostProcessing = true;
            ApplySettings();
        }

        public static void ApplySettings()
        {
            Resolution newResolution = Screen.resolutions[PivotalManager.instance.settings.video.resolutionIndex];
            bool fs = PivotalManager.instance.settings.video.useFullscreen;
            FullScreenMode fullscreenMode = (PivotalManager.instance.settings.video.useExclusiveFullscreen) ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.MaximizedWindow;
            fullscreenMode = (fs) ? fullscreenMode : FullScreenMode.Windowed;
            int syncCount = (PivotalManager.instance.settings.video.syncEveryFrame) ? 1 : 0;

            if (newResolution.width != Screen.currentResolution.width || newResolution.height != Screen.currentResolution.height || fullscreenMode != Screen.fullScreenMode)
            {
                Screen.SetResolution(newResolution.width, newResolution.height, fullscreenMode, newResolution.refreshRate);
            }

            QualitySettings.vSyncCount = syncCount;
            QualitySettings.antiAliasing = PivotalManager.instance.settings.video.antiAliasingIndex;
            PivotalManager.instance.settings.Save();
        }
    }

    [System.Serializable]
    public class AudioSettings
    {
        public float masterVolume;
        public float musicVolume;
        public float soundVolume;

        public AudioSettings()
        {
            masterVolume = musicVolume = soundVolume = 1.0f;
        }
    }

    [System.Serializable]
    public class GameSettings
    {
        public bool recordReplays;
        public float cameraTurnSpeed;
        public string username;

        public GameSettings()
        {
            recordReplays = true;
            cameraTurnSpeed = 0.1f;
            username = "Pivotal Gamer";
        }
    }
}