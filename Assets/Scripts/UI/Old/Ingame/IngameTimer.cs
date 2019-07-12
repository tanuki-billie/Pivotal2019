using UnityEngine;
using TMPro;
using ElementStudio.Pivotal.Levels;

namespace ElementStudio.Pivotal
{
    [RequireComponent(typeof(TMP_Text))]
    public class IngameTimer : MonoBehaviour
    {
        private TMP_Text text; //This lol
        public const string formatString = "{0:0}:{1:00}<size=54>.{2:00}</size>";

        void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        void Update()
        {
            float minutes = Mathf.Floor(LevelPlayer.instance.levelTime / 60);
            float seconds = Mathf.Floor(LevelPlayer.instance.levelTime % 60);
            float milliseconds = (LevelPlayer.instance.levelTime - Mathf.Floor(LevelPlayer.instance.levelTime)) * 100;
            text.text = string.Format(formatString, minutes, seconds, milliseconds);
        }
    }
}