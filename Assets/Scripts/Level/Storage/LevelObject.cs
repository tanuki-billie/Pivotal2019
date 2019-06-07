using UnityEngine;

namespace ElementStudio.Pivotal
{
    [CreateAssetMenu(fileName = "Level", menuName = "Pivotal/Level", order = 1)]
    public class LevelObject : ScriptableObject
    {
        public string levelTitle;
        public string internalName;
        public string levelDescription;
        public Sprite screenshot;
        public string author;
        public int buildIndex;
        public float medalTime;
    }
}