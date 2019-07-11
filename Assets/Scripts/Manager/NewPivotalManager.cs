using UnityEngine;
using System.IO;
using ElementStudio.Pivotal.Levels;

namespace ElementStudio.Pivotal.Manager
{
    public class NewPivotalManager : MonoBehaviour
    {
        //Static reference for singleton behavior
        public static NewPivotalManager instance;
        //Our settings file that is loaded.
        public PivotalSettings settings;

        //Setup our singleton and load our settings.
        void Awake()
        {
            if (instance != null) Destroy(this.gameObject);
            instance = this;
            settings.Load();
        }

        //DEBUG: Method to test level loading when game loads.
        void Start()
        {
            LoadLevel();
        }

        //Sets up directories for replays, levels, and associated records.
        void SetupDirectories()
        {
            string path = Path.Combine(Application.persistentDataPath, Level.universalLevelPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        //Function to load a level that exists on disk.
        public void LoadLevel(string levelID, bool isCommunityLevel = false, LevelMode mode = LevelMode.Play)
        {
            LevelManager.instance.mode = mode;
            LevelManager.instance.LoadLevel(levelID, isCommunityLevel);
        }

        //Function to load a brand new level for editing purposes.
        public void LoadLevel(bool isCommunityLevel = true, LevelMode mode = LevelMode.Edit)
        {
            LevelManager.instance.mode = mode;
            LevelManager.instance.LoadNewLevel(isCommunityLevel);
        }
    }
}