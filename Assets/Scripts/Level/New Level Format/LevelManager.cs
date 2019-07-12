using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElementStudio.Pivotal.Levels
{
    //Class for managing level loading and changing game state from menu to level.
    public class LevelManager : MonoBehaviour
    {
        //Instance variable
        public static LevelManager instance;
        //The level that we have loaded. Null if no level is loaded.
        public Level level;
        //The level mode
        public LevelMode mode;
        //Is the level loaded?
        public bool isLoaded;
        //The tile manager
        public TileManager tiles;
        //Our level builder
        public LevelBuilder builder;

        void Awake()
        {
            if (instance != null) Destroy(this.gameObject);
            instance = this;
            tiles = GetComponent<TileManager>();
        }

        public void LoadLevel(string level, bool isCommunityLevel)
        {
            this.level = Level.Load(level, isCommunityLevel);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        public void LoadNewLevel(bool isCommunityLevel)
        {
            level = new Level();
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        //Called by the builder in order to load the level
        public void Load()
        {
            isLoaded = true;
            builder.Load(level, mode);
        }

        public void UnloadLevel()
        {
            level = null;
            isLoaded = false;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}