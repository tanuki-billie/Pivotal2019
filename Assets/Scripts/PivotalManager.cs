using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

namespace ElementStudio.Pivotal
{
    public class PivotalManager : MonoBehaviour
    {
        [Header("Basic")]
        public static PivotalManager instance;
        public int BuildVersion = 3;

        [Header("Replay State")]
        public bool isReplay = false;
        public string replayName = "";
        [HideInInspector]
        public ReplayKeeper keeper;
        public float cameraTurnSpeed = 0.25f;

        void Awake()
        {
            cameraTurnSpeed = PlayerPrefs.GetFloat("CameraTurnSpeed", 0.1f);
            Application.targetFrameRate = 60;
            if (instance != null) Destroy(this.gameObject);
            else instance = this;
            DontDestroyOnLoad(this.gameObject);
            SetupDirectories();
            SetupReferences();
        }

        void SetupReferences()
        {
            keeper = GetComponent<ReplayKeeper>();
        }

        public void StartReplay(string replayName)
        {
            isReplay = true;
            Replay replay = Replay.Load(replayName);
            if (replay == null)
            {
                Debug.LogError("Replay not found!");
                return;
            }
            keeper.currentReplay = replay;
            SceneManager.LoadScene(keeper.currentReplay.level);
        }

        public void StopReplay()
        {
            isReplay = false;
            keeper.currentReplay = null;
            Debug.Log("Replay is over!");
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