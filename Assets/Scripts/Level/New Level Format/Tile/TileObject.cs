using UnityEngine;
using UnityEngine.Tilemaps;

namespace ElementStudio.Pivotal.Levels
{
    [CreateAssetMenu(fileName = "New Tile", menuName = "Pivotal/Level/Tile Asset", order = 1)]
    public class TileObject : ScriptableObject
    {
        public TileBase tileID;
    }
}