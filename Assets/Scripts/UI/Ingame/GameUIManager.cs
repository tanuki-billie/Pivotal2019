using UnityEngine;
using UnityEngine.UI;
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
        TweenCallback endGo;

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
        }

        public void DoCountdown(RectTransform target, float scale = 1.2f)
        {
            target.gameObject.SetActive(true);
            target.DOScale(new Vector3(scale, scale, 1f), 1f);
        }

        public void CompleteCountdown(RectTransform target)
        {
            target.gameObject.SetActive(false);
        }

        public void DoGo(float shakeFactor = 0.25f)
        {
            TurnOnTimer();
            endGo += EndGo;
            countdownGoText.gameObject.SetActive(true);
            Camera.main.transform.DOShakePosition(0.3f, shakeFactor).OnComplete(endGo);

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