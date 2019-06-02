using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace ElementStudio.Pivotal
{
    public class RecordKeeper : MonoBehaviour
    {
        //Some private variables.
        public const string ingameRecordSavePath = "/Records/{0}.pivr";
        public const string communityRecordSavePath = "/Community/Records/{1}/{0}.pivr";

        public LevelRecords records;

        public void RecordTime(float time, string saveName, string levelAuthor, bool communityLevel = false)
        {
            records.completionTimes.Add(time);
            Debug.Log("New entry! Record: " + time + "s");
            if (float.IsNaN(records.recordTime) || time < records.recordTime)
            {
                records.recordTime = time;
                Debug.Log("New record! Record: " + time + "s");
                Level.instance.newRecord = true;
            }
            records.Save(saveName, communityLevel, levelAuthor);
        }

        public void Load(string saveName, string levelAuthor, bool communityLevel = false)
        {
            records = LevelRecords.Load(saveName, communityLevel, levelAuthor);
            if (float.IsNaN(records.recordTime))
            {
                //We have not set a record for this level
            }
        }
    }

    [System.Serializable]
    public struct LevelRecords
    {
        public float recordTime;
        public List<float> completionTimes;

        public static LevelRecords Load(string levelName, bool communityLevel = false, string levelAuthor = "")
        {
            Debug.Log(Application.persistentDataPath);
            string path = Application.persistentDataPath + ((communityLevel) ? RecordKeeper.communityRecordSavePath : RecordKeeper.ingameRecordSavePath);
            path = string.Format(path, levelName, levelAuthor);
            Debug.Log(path);
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
                Debug.Log("Records file loaded at " + path);
                return JsonUtility.FromJson<LevelRecords>(contents);
            }
            catch (System.Exception e)
            {
                Debug.Log("File not found! Here's the info you're gonna need: " + e);
                File.Create(path);
                return new LevelRecords(float.NaN);
            }
        }

        public void Save(string levelName, bool communityLevel = false, string levelAuthor = "")
        {
            string contents = JsonUtility.ToJson(this, true);
            string path = Application.persistentDataPath + ((communityLevel) ? RecordKeeper.communityRecordSavePath : RecordKeeper.ingameRecordSavePath);
            path = string.Format(path, levelName, levelAuthor);
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(contents);
            }
            fs.Close();
            Debug.Log("Records file saved at " + path);
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