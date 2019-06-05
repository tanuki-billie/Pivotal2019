using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using System;

namespace ElementStudio.Pivotal
{
    public class ReplayKeeper : MonoBehaviour
    {
        public Replay currentReplay;

        public void SetPlayerReplay()
        {
            Level.instance.playerReference.GetComponent<ReplayInputHandler>().SetReplay(currentReplay);
        }
    }

    [Serializable]
    public class Replay
    {
        public int level;
        public List<RecordInput> recordedInputs;
        public DateTime timestamp;
        public int GameVersion;
        public const string extension = ".pivreplay";
        public const string replayPath = "Replays";

        public Replay(List<RecordInput> inputs, int scene)
        {
            level = scene;
            recordedInputs = inputs;
            timestamp = DateTime.Now;
        }

        public static Replay Load(string replayName)
        {
            //We're just gonna assume that replayName leads directly to a replay
            string path = Path.Combine(Application.persistentDataPath, replayPath);
            string file = replayName + extension;
            path = Path.Combine(path, file);
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
                Debug.Log("Replay file loaded at " + path);
                return JsonUtility.FromJson<Replay>(contents);
            }
            catch (System.Exception e)
            {
                Debug.Log("File not found! Here's the info you're gonna need: " + e);
                File.Create(path);
                return null;
            }
        }

        public static List<string> GetReplayList()
        {
            List<string> result = new List<string>();
            string path = Path.Combine(Application.persistentDataPath, replayPath);
            foreach (string file in Directory.GetFiles(path, "*" + extension, SearchOption.TopDirectoryOnly))
            {
                result.Add(Path.GetFileNameWithoutExtension(file));
            }
            return (result);
        }

        public void Save(string replayName)
        {
            string path = Path.Combine(Application.persistentDataPath, replayPath);
            string file = replayName + extension;
            path = Path.Combine(path, file);
            string contents = JsonUtility.ToJson(this, true);
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(contents);
            }
            fs.Close();
            Debug.Log("Replay file saved at " + path);
        }
    }
}