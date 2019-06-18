using UnityEngine;
using System.IO;
using ElementStudio.Pivotal.Levels;

namespace ElementStudio.Pivotal.Manager
{
    public class NewPivotalManager : MonoBehaviour
    {
        //References
        public static NewPivotalManager instance;
        public PivotalSettings settings;

        void Awake()
        {
            if (instance != null) Destroy(this.gameObject);
            instance = this;
            settings.Load();
            ApplySettings();
        }

        void Start()
        {
            LoadLevel();
        }

        public void ApplySettings()
        {
            VideoSettings.ApplySettings();
        }

        void SetupDirectories()
        {
            //Sets up directories for replays, levels, and associated records.
            string path = Path.Combine(Application.persistentDataPath, Levels.Level.universalLevelPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void LoadLevel(string levelID, bool isCommunityLevel = false, LevelMode mode = LevelMode.Play)
        {
            LevelManager.instance.mode = mode;
            LevelManager.instance.LoadLevel(levelID, isCommunityLevel);
        }

        public void LoadLevel(bool isCommunityLevel = true, LevelMode mode = LevelMode.Edit)
        {
            LevelManager.instance.mode = mode;
            LevelManager.instance.LoadNewLevel(isCommunityLevel);
        }
    }
}