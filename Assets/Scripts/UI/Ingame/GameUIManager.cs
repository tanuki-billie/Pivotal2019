using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using ElementStudio.Pivotal.Levels;

namespace ElementStudio.Pivotal
{
    //Yeah, this class will need a revamp as well
    public class GameUIManager : MonoBehaviour
    {
        [Header("Countdown")]
        private EventSystem eventSystem;

        [Header("Timer")]
        public RectTransform timerText;
        public const string formatString = "{0:0}:{1:00}<size=48>.{2:00}</size>";
        public TMP_Text recordTimer;

        void Awake()
        {
            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        }

        void TurnOnTimer()
        {
            timerText.gameObject.SetActive(true);
            if (!(LevelPlayer.instance.isReplay || LevelPlayer.instance.hasNoRecord)) TurnOnRecordTimer();

        }

        void TurnOnRecordTimer()
        {
            /*
            float recordTime = Level.instance.records.records.recordTime;
            float minutes = Mathf.Floor(recordTime / 60);
            float seconds = Mathf.Floor(recordTime % 60);
            float milliseconds = (recordTime - Mathf.Floor(recordTime)) * 100;
            recordTimer.gameObject.SetActive(true);
            recordTimer.text = string.Format(formatString, minutes, seconds, milliseconds);
            */
        }

        public void DoGo()
        {
            TurnOnTimer();
        }
    }
}