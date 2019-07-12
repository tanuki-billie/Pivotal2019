using UnityEngine;
using ElementStudio.Pivotal.Manager;

namespace ElementStudio.Pivotal.Menu
{
    public class MainMenuLoader : MonoBehaviour
    {
        private MenuStateManager _manager;
        private bool gameAlreadyLoaded = false;
        public PressAnyKey pakReference;
        public MenuStateManager managerToSetup;

        //Get menu state manager
        void Awake()
        {
            _manager = GetComponent<MenuStateManager>();
        }

        //Check if game has been loaded
        void Start()
        {
            gameAlreadyLoaded = PivotalManager.instance.hasGameStarted;
            if (gameAlreadyLoaded)
            {
                pakReference.onPressAnyKey.Invoke();
                pakReference.gameObject.SetActive(false);
            }
            else
            {
                _manager.StartMenu();
                PivotalManager.instance.hasGameStarted = true;
            }
        }
    }
}