using UnityEngine;
using ElementStudio.Pivotal;

namespace ElementStudio.Pivotal
{
    public class StartCountdown : MonoBehaviour
    {
        public GameObject playerInstance;
        public GameUIManager gameUIManager;
        [HideInInspector]
        public GameObject playerReference;

        private float timer = 5.0f;
        private float goDuration = 0.5f;
        private float currentTimer = 0f;

        void Awake()
        {
            if (playerInstance == null)
            {
                Debug.LogError("[StartCountdown] No prefab has been set for our player! Code Red!");
            }
            if (gameUIManager == null)
            {
                Debug.LogWarning("Hey, you're supposed to set the UI manager! We'll do it for you anyways, but make sure you set it for next time.");
                gameUIManager = GameObject.Find("Game UI").GetComponent<GameUIManager>();
            }
            currentTimer = timer;
            playerReference = Instantiate(playerInstance, Vector2.zero, Quaternion.identity);
        }

        void Update()
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0f)
            {
                StartGame();
            }
        }

        void StartGame()
        {

        }
    }
}