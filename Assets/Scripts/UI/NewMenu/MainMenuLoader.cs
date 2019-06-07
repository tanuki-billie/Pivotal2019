using UnityEngine;

namespace ElementStudio.Pivotal.Menu
{
    public class MainMenuLoader : MonoBehaviour
    {
        private MenuStateManager _manager;
        private bool gameAlreadyLoaded = false;
        public PressAnyKey pakReference;
        public MenuStateManager managerToSetup;

        void Awake()
        {
            _manager = GetComponent<MenuStateManager>();
            //TODO: Implement New Pivotal Game Manager that lets us determine if the game is already loaded

        }

        void Start()
        {
            gameAlreadyLoaded = PivotalManager.instance.gameStarted;
            if (gameAlreadyLoaded)
            {
                pakReference.onPressAnyKey.Invoke();
                pakReference.gameObject.SetActive(false);
            }
            else
            {
                _manager.StartMenu();
                PivotalManager.instance.gameStarted = true;
            }
        }
    }
}