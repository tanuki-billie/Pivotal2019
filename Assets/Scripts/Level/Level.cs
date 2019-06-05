using UnityEngine;
using System.Collections.Generic;

namespace ElementStudio.Pivotal
{
    public class Level : MonoBehaviour
    {
        [Header("Basic Level Information")]
        [Tooltip("The Level description file")]
        public LevelObject levelObject;

        [Header("Times")]
        [Tooltip("The player's records for this level, containing their best time and all their completion times.")]
        public RecordKeeper records;

        [Header("Currenet State")]
        public LevelState currentLevelState = LevelState.Beginning;
        public GameObject pauseMenuPrefab;
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
        private float timeRunningOnPause;
        public bool hasNoRecord = false;

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
                records.Load(levelObject.internalName, levelObject.author, false);
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
                records.RecordTime(currentTiming, levelObject.internalName, levelObject.author, false);
            }

        }

        public void PauseLevel()
        {
            isPaused = true;
            timeRunningOnPause = currentTiming;
            Time.timeScale = 0f;
            timeRunning = false;
            if (isReplay)
            {
                playerReference.GetComponent<ReplayInputHandler>().enabled = false;
            }
            Instantiate(pauseMenuPrefab, Vector3.zero, Quaternion.identity);
        }

        public void UnpauseLevel()
        {
            isPaused = false;
            currentTiming = timeRunningOnPause;
            if (isReplay)
            {
                playerReference.GetComponent<ReplayInputHandler>().enabled = true;
            }
            Time.timeScale = 1f;
            timeRunning = true;
        }
    }

    public enum LevelState
    {
        Beginning,
        Playing,
        Finished
    }
}