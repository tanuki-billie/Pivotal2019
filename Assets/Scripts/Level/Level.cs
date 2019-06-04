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

        [Header("Times")]
        [Tooltip("The time, in seconds, it would take to earn a medal for clearing this level.")]
        public float medalCompletionTime = 0f;
        [Tooltip("The player's records for this level, containing their best time and all their completion times.")]
        public RecordKeeper records;

        [Header("Currenet State")]
        public LevelState currentLevelState = LevelState.Beginning;
        public bool isPaused = false;
        public bool isReplay = false;

        [HideInInspector]
        public bool timeRunning = false;
        [HideInInspector]
        public bool newRecord = false;
        public float currentTiming = 0f;
        public static Level instance;

        [HideInInspector]
        public GameObject playerReference;

        void Awake()
        {
            if (instance != null) Destroy(this.gameObject);
            instance = this;
            if (PivotalManager.instance.isReplay)
            {
                isReplay = true;
            }
            else
            {
                //Records are only loaded in non-replay scenarios
                records.Load(saveName, levelAuthor, communityLevel);
            }

        }

        public void StartLevel()
        {
            timeRunning = true;
            currentLevelState = LevelState.Playing;
            playerReference.GetComponent<GravityPivotalController>().enabled = true;
            playerReference.GetComponent<PlayerGrow>().enabled = false;
            if (isReplay) playerReference.GetComponent<ReplayInputHandler>().StartPlaying();
            Camera.main.GetComponent<CameraFollow>().enabled = true;
        }

        void Update()
        {
            if (timeRunning)
            {
                currentTiming += Time.deltaTime;
            }
        }

        public void CompleteLevel()
        {
            timeRunning = false;
            currentLevelState = LevelState.Finished;
            Level.instance.playerReference.GetComponent<GravityPivotalController>().enabled = false;
            if (!isReplay)
            {
                //Do not save replays and records if we're watching a replay!
                InputRecorder.instance.SaveInputs();
                records.RecordTime(currentTiming, saveName, levelAuthor, communityLevel);
            }

        }
    }

    public enum LevelState
    {
        Beginning,
        Playing,
        Finished
    }
}