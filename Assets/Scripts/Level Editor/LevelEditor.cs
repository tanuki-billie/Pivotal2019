using UnityEngine;
using ElementStudio.Pivotal.Levels;

namespace ElementStudio.Pivotal.Editor
{
    public class LevelEditor : MonoBehaviour
    {
        //Singleton instance for level editor
        public static LevelEditor instance;
        //What tile are we currently using?
        public TileObject currentTileSelection;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }
    }
}