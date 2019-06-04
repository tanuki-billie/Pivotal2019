using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace ElementStudio.Pivotal
{
    public class LevelChoice : MonoBehaviour
    {
        public TMP_Text levelNameText;
        string levelName;
        public int levelBuildIndexToPlay;

        public void PlayLevel()
        {
            SceneManager.LoadScene(levelBuildIndexToPlay);
        }

        public void SetLevelName(string name, int index = -1)
        {
            levelName = name;
            levelNameText.text = name;
            levelBuildIndexToPlay = index;
        }
    }
}