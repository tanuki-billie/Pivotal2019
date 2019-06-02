using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace ElementStudio.Pivotal
{
    public class GameUIManager : MonoBehaviour
    {
        [Header("Countdown")]
        public RectTransform countdownGetReadyText;
        public RectTransform countdownGoText, countdown3Text, countdown2Text, countdown1Text;

        [Header("Timer")]
        public RectTransform timerText;
        TweenCallback endGo;

        void TurnOnTimer()
        {
            timerText.gameObject.SetActive(true);
        }

        public void DoCountdown(RectTransform target, float scale = 1.2f)
        {
            target.gameObject.SetActive(true);
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
    }
}