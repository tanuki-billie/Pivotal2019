using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace ElementStudio.Pivotal
{
    public class LevelChoice : MonoBehaviour
    {
        public TMP_Text levelNameText;
        public TMP_Text recordText;
        string levelName;
        public int levelBuildIndexToPlay;

        public void PlayLevel()
        {
            SceneManager.LoadScene(levelBuildIndexToPlay);
        }

        public void SetChoice(string name, float record = float.NaN, int index = -1)
        {
            levelName = name;
            levelNameText.text = name;
            levelBuildIndexToPlay = index;
            if (float.IsNaN(record))
            {
                recordText.text = "No record set";
                recordText.color = Color.red;
            }
            else
            {
                recordText.text = string.Format("{0:00}:{1:00}.{2:00}", Mathf.Floor(record / 60), Mathf.Floor(record % 60), (record - Mathf.Floor(record)) * 100);
                recordText.color = Color.green;
            }
        }
    }
}