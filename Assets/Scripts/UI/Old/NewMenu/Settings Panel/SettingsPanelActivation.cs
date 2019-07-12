using UnityEngine;

namespace ElementStudio.Pivotal.Menu
{
    public class SettingsPanelActivation : MonoBehaviour
    {
        bool isOpen = false;
        MenuState state;
        public MenuState parentState;

        void Awake()
        {
            state = GetComponent<MenuState>();
        }
        void Update()
        {
            if (parentState.isOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isOpen = !isOpen;
                    if (isOpen)
                    {
                        state.OpenMenu();
                    }
                    else
                    {
                        state.CloseMenu();
                    }
                }
            }
            else if (isOpen == true)
            {
                state.CloseMenu();
                isOpen = false;
            }
        }
    }
}