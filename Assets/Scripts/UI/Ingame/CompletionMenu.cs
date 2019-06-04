using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


namespace ElementStudio.Pivotal
{
    public class CompletionMenu : MonoBehaviour
    {
        [Header("UI Objects")]
        public TMP_Text timeText;
        public GameObject newRecordText;
        public GameObject retryButton;

        void OnEnable()
        {
            timeText.text = string.Format("{0:0.00}s", Level.instance.currentTiming);
            if (!Level.instance.isReplay)
            {
                if (Level.instance.newRecord)
                {
                    newRecordText.SetActive(true);
                    newRecordText.transform.DOShakePosition(1.0f);
                }
            }
        }

        public void MenuOption(bool retry)
        {
            if (retry)
            {
                Scene current = SceneManager.GetActiveScene();
                SceneManager.LoadScene(current.buildIndex);
            }
            else
            {
                if (Level.instance.isReplay)
                {
                    PivotalManager.instance.StopReplay();
                }
                SceneManager.LoadScene(0);
            }

        }
    }
}