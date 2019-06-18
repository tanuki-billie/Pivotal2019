using System.IO;
using UnityEngine;

namespace ElementStudio.Pivotal.Manager
{
    [System.Serializable]
    public class PivotalSettings
    {
        public VideoSettingsFile video;
        public AudioSettingsFile audio;
        public GameSettingsFile game;
        const string fileName = "settings.json";

        //Load settings
        public void Load()
        {
            Debug.Log("Creating new Pivotal Settings");
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
        }

        public void Initialize()
        {
            video = new VideoSettingsFile(true);
            audio = new AudioSettingsFile();
            game = new GameSettingsFile();
            Save();
        }

        public void Save()
        {
            string contents = JsonUtility.ToJson(this, true);
            string path = Path.Combine(Application.persistentDataPath, fileName);
            File.WriteAllText(path, contents);
        }
    }

    [System.Serializable]
    public class VideoSettingsFile
    {
        public int resolutionIndex;
        public bool useFullscreen;
        public bool useExclusiveFullscreen;
        public bool syncEveryFrame;
        public int antiAliasingIndex;
        public bool usePostProcessing;

        public VideoSettingsFile(bool playing = false)
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
            NewPivotalManager.instance.ApplySettings();
        }
    }

    [System.Serializable]
    public class AudioSettingsFile
    {
        public float masterVolume;
        public float musicVolume;
        public float soundVolume;

        public AudioSettingsFile()
        {
            masterVolume = musicVolume = soundVolume = 1.0f;
        }
    }

    [System.Serializable]
    public class GameSettingsFile
    {
        public bool recordReplays;
        public float cameraTurnSpeed;
        public string username;

        public GameSettingsFile()
        {
            recordReplays = true;
            cameraTurnSpeed = 0.1f;
            username = "Pivotal Gamer";
        }
    }
}