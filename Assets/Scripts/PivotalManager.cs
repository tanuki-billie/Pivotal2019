using UnityEngine;
using System.IO;

namespace ElementStudio.Pivotal
{
    public class PivotalManager : MonoBehaviour
    {
        [Header("Basic")]
        public static PivotalManager instance;

        void Awake()
        {
            if (instance != this) Destroy(this.gameObject);
            else instance = this;
            SetupDirectories();
        }

        //Sets up the directories for replays and records if they aren't setup already.
        void SetupDirectories()
        {
            string path = Path.Combine(Application.persistentDataPath, LevelRecord.ingamePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Created path " + path);
            }
            path = Path.Combine(Application.persistentDataPath, LevelRecord.communityPath, LevelRecord.ingamePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Created path " + path);
            }
            path = Path.Combine(Application.persistentDataPath, Replay.replayPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Created path " + path);
            }
        }
    }
}