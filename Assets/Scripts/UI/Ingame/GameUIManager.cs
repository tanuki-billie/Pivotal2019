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

        void TurnOnTimer()
        {
            timerText.gameObject.SetActive(true);
        }

        void DoCountdown(RectTransform target, float scale = 1.2f)
        {
            target.gameObject.SetActive(true);
        }

        void CompleteCountdown(RectTransform target)
        {
            target.gameObject.SetActive(false);
        }

        void DoGo(float shakeFactor = 0.25f)
        {
            countdownGoText.gameObject.SetActive(true);
            Camera.main.transform.DOShakePosition(0.1f, shakeFactor);
        }
    }
}