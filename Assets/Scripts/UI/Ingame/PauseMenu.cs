using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace ElementStudio.Pivotal
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject saveReplayButton;

        void OnEnable()
        {
            if (Level.instance.isReplay)
            {
                saveReplayButton.GetComponent<Button>().interactable = false;
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeGame();
            }
        }
        public void ResumeGame()
        {
            Level.instance.UnpauseLevel();
            Destroy(gameObject);
        }

        public void SaveReplayUpToCurrentPoint()
        {
            InputRecorder.instance.SaveInputs("_INCOMPLETE");
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void RestartLevel()
        {
            Level.instance.UnpauseLevel();
            Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.buildIndex);
        }

        public void OpenFeedback(string url)
        {
            Application.OpenURL(url);
        }
    }
}