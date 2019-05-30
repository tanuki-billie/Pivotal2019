using UnityEngine;
using TMPro;

namespace ElementStudio.Pivotal
{
    [RequireComponent(typeof(TMP_Text))]
    public class IngameTimer : MonoBehaviour
    {
        private TMP_Text text; //This lol
        public const string formatString = "{0:0}:{1:00}<size=54>.{2:00}</size>";
        public Level currentLevel;

        void Awake()
        {
            text = GetComponent<TMP_Text>();
            currentLevel = GameObject.Find("Level Manager").GetComponent<Level>();
        }

        void Update()
        {
            float minutes = Mathf.Floor(currentLevel.currentTiming / 60);
            float seconds = Mathf.Floor(currentLevel.currentTiming % 60);
            float milliseconds = (currentLevel.currentTiming - Mathf.Floor(currentLevel.currentTiming)) * 100;
            text.text = string.Format(formatString, minutes, seconds, milliseconds);
        }
    }
}