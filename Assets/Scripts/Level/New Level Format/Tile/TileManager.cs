using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Levels
{
    public class TileManager : MonoBehaviour
    {
        public List<TileObject> tileDirectory = new List<TileObject>();

        public TileBase GetTile(ushort tile)
        {
            if (tile >= tileDirectory.Count) return tileDirectory[0].tileID;
            return tileDirectory[tile].tileID;
        }
    }
}