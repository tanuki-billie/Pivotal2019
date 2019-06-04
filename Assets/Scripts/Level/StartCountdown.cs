using UnityEngine;
using ElementStudio.Pivotal;

namespace ElementStudio.Pivotal
{
    public class StartCountdown : MonoBehaviour
    {
        public GameObject playerInstance;
        public GameUIManager gameUIManager;
        public GameObject playerReference;

        private float timer = 3.0f;
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

        void Start()
        {
            Level.instance.playerReference = playerReference;
        }

        void Update()
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0f)
            {
                StartGame();
            }
            else if (currentTimer <= 1f)
            {
                gameUIManager.CompleteCountdown(gameUIManager.countdown2Text);
                gameUIManager.DoCountdown(gameUIManager.countdown1Text);
            }
            else if (currentTimer <= 2f)
            {
                gameUIManager.CompleteCountdown(gameUIManager.countdown3Text);
                gameUIManager.DoCountdown(gameUIManager.countdown2Text);
            }
            else if (currentTimer <= 3f)
            {
                gameUIManager.CompleteCountdown(gameUIManager.countdownGetReadyText);
                gameUIManager.DoCountdown(gameUIManager.countdown3Text);
            }
            else
            {
                gameUIManager.DoCountdown(gameUIManager.countdownGetReadyText);
            }
        }

        void StartGame()
        {
            Level.instance.StartLevel();
            gameUIManager.CompleteCountdown(gameUIManager.countdown1Text);
            gameUIManager.DoGo();
            Destroy(this);
        }
    }
}