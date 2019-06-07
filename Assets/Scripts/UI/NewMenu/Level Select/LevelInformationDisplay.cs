using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ElementStudio.Pivotal.Menu
{
    public class LevelInformationDisplay : MonoBehaviour
    {
        [Header("UI Objects")]
        public Image screenshotDisplay;
        public TMP_Text descriptionText;
        public TMP_Text authorText;
        public TMP_Text medalTimeText;
        public Button goButton;

        CanvasGroup _canvasGroup;
        LevelObject selectedObject;
        public static LevelInformationDisplay instance;

        void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
            _canvasGroup = GetComponent<CanvasGroup>();
            if (selectedObject == null)
            {
                _canvasGroup.alpha = 0f;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            }
            goButton.onClick.AddListener(GoToLevel);
        }

        public void UpdateCanvas(LevelObject selectedLevel)
        {
            selectedObject = selectedLevel;
            authorText.text = selectedObject.author;
            descriptionText.text = selectedObject.levelDescription;
            screenshotDisplay.sprite = selectedObject.screenshot;
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void GoToLevel()
        {
            SceneManager.LoadScene(selectedObject.buildIndex);
        }

        public void EndSelect()
        {
            selectedObject = null;
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}