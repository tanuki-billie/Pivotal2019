using UnityEngine;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Levels
{
    [System.Serializable]
    public struct LevelSettings
    {
        //The author of the level
        public string levelAuthor;
        //The level's formal title.
        public string levelTitle;
        //The spawn positions for the level. We can find out if the level supports multiple players here.
        public List<LevelSpawn> spawnPositions;
        //The goal positions for the level.
        public List<LevelGoal> levelGoals;
        //The bytes that make up the level screenshot
        public byte[] screenshot;
        //The time it would take to get a medal for speedy completion
        public float medalCompletionTime;
        //The locations of the tokens that are collectible.
        public Vector2[] medalLocations;
        //The colors for background and foreground
        public Color backgroundColor, foregroundColor;
        //Is this a community level? (Determines save path)
        public bool isCommunityLevel;

        public LevelSettings(bool isCommunityLevel)
        {
            levelAuthor = levelTitle = string.Empty;
            spawnPositions = new List<LevelSpawn>();
            levelGoals = new List<LevelGoal>();
            screenshot = null;
            medalCompletionTime = 0;
            medalLocations = new Vector2[] { Vector2.zero, Vector2.zero, Vector2.zero };
            backgroundColor = Color.black;
            foregroundColor = Color.white;
            this.isCommunityLevel = !isCommunityLevel;
        }
    }

    [System.Serializable]
    public struct LevelSpawn
    {
        public byte playerNumber;
        public Vector2 coords;
    }

    [System.Serializable]
    public struct LevelGoal
    {
        public Vector2 coords;
        public Vector2 scale;
    }
}