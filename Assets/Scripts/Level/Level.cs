using UnityEngine;
using System.Collections.Generic;

namespace ElementStudio.Pivotal
{
    public class Level : MonoBehaviour
    {
        [Header("Basic Level Information")]
        [Tooltip("The display name of the level.")]
        public string displayName;
        [Tooltip("The file name to save the level as")]
        public string saveName;
        [Tooltip("Who owns this level?")]
        public string levelAuthor = "";
        [Tooltip("Determines if this is a built-in level or a community level.")]
        public bool communityLevel = false;

        //Some private variables.
        public const string ingameRecordSavePath = "lvl/ingame/{0}.pivr";
        public const string communityRecordSavePath = "lvl/community/{1}/{0}.pivr";

        [Header("Times")]
        [Tooltip("The time, in seconds, it would take to earn a medal for clearing this level.")]
        public float medalCompletionTime = 0f;
        [Tooltip("The player's records for this level, containing their best time and all their completion times.")]
        public LevelRecords records;

        [HideInInspector]
        public bool timeRunning = false;
        public float currentTiming = 0f;

        void Awake()
        {
            records = LevelRecords.Load(saveName, communityLevel, levelAuthor);
            if (float.IsNaN(records.recordTime))
            {
                //We have not set a record for this level
            }
            StartLevel();
        }

        void StartLevel()
        {
            timeRunning = true;
        }

        void Update()
        {
            if (timeRunning)
            {
                currentTiming += Time.deltaTime;
            }
        }

        void CompleteLevel()
        {
            timeRunning = false;
            records.completionTimes.Add(currentTiming);
            if (float.IsNaN(records.recordTime) || currentTiming < records.recordTime)
            {
                records.recordTime = currentTiming;
            }
            records.Save(saveName, communityLevel, levelAuthor);
        }
    }

    [System.Serializable]
    public struct LevelRecords
    {
        public float recordTime;
        public List<float> completionTimes;

        public static LevelRecords Load(string levelName, bool communityLevel = false, string levelAuthor = "")
        {
            string contents;
            string path = Application.persistentDataPath + ((communityLevel) ? Level.communityRecordSavePath : Level.ingameRecordSavePath);
            try
            {
                contents = System.IO.File.ReadAllText(string.Format(path, levelName, levelAuthor));
                return JsonUtility.FromJson<LevelRecords>(contents);
            }
            catch (System.Exception e)
            {
                Debug.Log("File not found! Here's the info you're gonna need: " + e);
                return new LevelRecords(float.NaN);
            }
        }

        public void Save(string levelName, bool communityLevel = false, string levelAuthor = "")
        {
            string contents = JsonUtility.ToJson(this, true);
            string path = Application.persistentDataPath + ((communityLevel) ? Level.communityRecordSavePath : Level.ingameRecordSavePath);

            System.IO.File.WriteAllText(string.Format(path, levelName, levelAuthor), contents);
        }

        public LevelRecords(float bestTime)
        {
            recordTime = bestTime;
            completionTimes = new List<float>();
        }

        public LevelRecords(float bestTime, List<float> completionTimes)
        {
            recordTime = bestTime;
            this.completionTimes = completionTimes;
        }
    }
}