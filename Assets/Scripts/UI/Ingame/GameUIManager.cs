using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace ElementStudio.Pivotal
{
    public class GameUIManager : MonoBehaviour
    {
        [Header("Countdown")]
        public RectTransform countdownGetReadyText;
        public RectTransform countdownGoText, countdown3Text, countdown2Text, countdown1Text;
        public CompletionMenu completionMenu;
        private EventSystem eventSystem;

        [Header("Timer")]
        public RectTransform timerText;
        public const string formatString = "{0:0}:{1:00}<size=48>.{2:00}</size>";
        public TMP_Text recordTimer;
        public TweenCallback endGo;

        void Awake()
        {
            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        }

        void Update()
        {
            if (Level.instance.currentLevelState == LevelState.Finished)
            {
                ShowCompletionMenu();
                this.enabled = false;
            }
        }

        void TurnOnTimer()
        {
            timerText.gameObject.SetActive(true);
            if (Level.instance.isReplay || Level.instance.hasNoRecord) return;
            float recordTime = Level.instance.records.records.recordTime;
            float minutes = Mathf.Floor(recordTime / 60);
            float seconds = Mathf.Floor(recordTime % 60);
            float milliseconds = (recordTime - Mathf.Floor(recordTime)) * 100;
            recordTimer.gameObject.SetActive(true);
            recordTimer.text = string.Format(formatString, minutes, seconds, milliseconds);
        }

        public void DoCountdown(RectTransform target, float scale = 1.05f)
        {
            target.gameObject.SetActive(true);
            target.DOScale(new Vector3(scale, scale, 1f), 1f);
        }

        public void CompleteCountdown(RectTransform target)
        {
            target.gameObject.SetActive(false);
        }

        public void DoGo(float shakeFactor = 1f)
        {
            TurnOnTimer();
            endGo += EndGo;
            countdownGoText.gameObject.SetActive(true);
            Camera.main.transform.DOShakePosition(0.8f, shakeFactor).OnComplete(endGo);

        }

        void EndGo()
        {
            countdownGoText.gameObject.SetActive(false);
        }

        public void ShowCompletionMenu()
        {
            completionMenu.gameObject.SetActive(true);
        }
    }
}