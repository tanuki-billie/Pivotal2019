using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Menu
{
    public class MenuStateManager : MonoBehaviour
    {
        public int firstSelected = 0;
        public List<MenuState> children = new List<MenuState>();
        int currentlySelected = 0;

        void Awake()
        {
            currentlySelected = firstSelected;
        }

        public void StartMenu()
        {
            children[currentlySelected].OpenMenu();
        }

        public void StartMenu(int first)
        {
            children[first].OpenMenu();
            currentlySelected = first;
        }

        public void ChangeMenuState(MenuState newState)
        {
            int newMenuSelection = children.IndexOf(newState);
            if (newMenuSelection == currentlySelected)
            {
                Debug.LogWarning("You can't change the current menu state to the same menu state!");
                return;
            }
            children[currentlySelected].CloseMenu();
            children[newMenuSelection].OpenMenu();
            currentlySelected = newMenuSelection;
        }

        public void ChangeMenuState(int newState)
        {
            if (newState == currentlySelected)
            {
                Debug.LogWarning("You can't change the current menu state to the same menu state!");
                return;
            }
            children[currentlySelected].CloseMenu();
            children[newState].OpenMenu();
            currentlySelected = newState;
        }
    }
}