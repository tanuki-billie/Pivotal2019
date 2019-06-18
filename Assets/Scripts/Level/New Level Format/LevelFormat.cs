using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Levels
{
    [Serializable]
    public class Level
    {
        //The internal path that Pivotal will use for loading levels. This same format will be used no matter what type of level is being stored, from internal levels to community levels.
        public const string universalLevelPath = "/Levels/";
        //The unique level ID.
        public string uuid;
        string savePath;
        public LevelSettings levelSettings;
        public List<Tile> tileData;

        public Level(bool isInternalLevel = false)
        {
            //We are creating a new level, so we need to generate a new level
            uuid = Guid.NewGuid().ToString();
            //Don't forget that for level settings, the bool for isCommunityLevel is inverted
            levelSettings = new LevelSettings(isInternalLevel);
            tileData = new List<Tile>();
            savePath = (isInternalLevel) ? Path.Combine(Application.streamingAssetsPath, universalLevelPath) : Path.Combine(Application.persistentDataPath, universalLevelPath);
        }

        public static Level Load(string levelID, bool isCommunityLevel)
        {
            //We are expecting that the levelID value is a GUID string.
            string path = (!isCommunityLevel) ? Path.Combine(Application.streamingAssetsPath, universalLevelPath) : Path.Combine(Application.persistentDataPath, universalLevelPath);
            string filename = string.Format("{0}.pivlevel", levelID);
            path = Path.Combine(path, filename);
            string contents;
            try
            {
                using (var fs = File.Open(path, FileMode.OpenOrCreate))
                {
                    using (var sr = new StreamReader(fs, true))
                    {
                        contents = sr.ReadToEnd();
                    }
                }
                return JsonUtility.FromJson<Level>(contents);
            }
            catch (System.Exception e)
            {
                Debug.Log("File not found! Here's the info you're gonna need: " + e);
                File.Create(path);
                return new Level(!isCommunityLevel);
            }
        }

        public void SaveToDisk()
        {
            string contents = JsonUtility.ToJson(this, true);
            string filename = string.Format("{0}.pivlevel", uuid);
            string path = Path.Combine(savePath, filename);
            FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(contents);
            }
            fs.Close();
        }
    }

    [Serializable]
    public struct Tile
    {
        public Vector2Int coords;
        public ushort tileType;
    }
}