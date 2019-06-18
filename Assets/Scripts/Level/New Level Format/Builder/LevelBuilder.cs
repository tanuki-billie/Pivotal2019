using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

namespace ElementStudio.Pivotal.Levels
{
    public class LevelBuilder : MonoBehaviour
    {
        public Tilemap tilemap;
        public Camera sceneCamera;

        public void Awake()
        {
            LevelManager.instance.builder = this;
            LevelManager.instance.Load();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Load(Level level, LevelMode mode = LevelMode.Play)
        {
            BuildLevel(level);
            if (mode == LevelMode.Play)
            {
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            Debug.LogWarning("Guess what? A scene was loaded!");
            if (scene.buildIndex > 1)
            {
                SceneManager.SetActiveScene(scene);
                sceneCamera = Camera.main;
                SetBackgroundColor();
            }
        }

        public void BuildLevel(Level build)
        {
            Vector3Int[] positions = new Vector3Int[build.tileData.Count];
            TileBase[] tileData = new TileBase[positions.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector3Int(build.tileData[i].coords.x, build.tileData[i].coords.y, 0);
                tileData[i] = LevelManager.instance.tiles.GetTile(build.tileData[i].tileType);
            }

            tilemap.SetTiles(positions, tileData);
            SetForegroundColor();
        }

        public void SetForegroundColor()
        {
            tilemap.color = LevelManager.instance.level.levelSettings.foregroundColor;
        }

        public void SetBackgroundColor()
        {
            sceneCamera.backgroundColor = LevelManager.instance.level.levelSettings.backgroundColor;
        }
    }

    public enum LevelMode
    {
        Play,
        Edit
    }
}