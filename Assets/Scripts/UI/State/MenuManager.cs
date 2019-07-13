using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.UI
{
    //Class to manage menus and the such. Allows us to switch states and the like.
    public class MenuManager : MonoBehaviour
    {
        public List<Menu> menus = new List<Menu>();
        public List<Toggle> tabs = new List<Toggle>();
        int currentlySelected = 0;

        void OnEnable()
        {
            InitMenu();
        }

        public void InitMenu()
        {
            for (int i = 0; i < menus.Count; i++)
            {
                menus[i].gameObject.SetActive(false);
            }
            menus[currentlySelected].gameObject.SetActive(true);
            tabs[currentlySelected].isOn = true;
        }

        public void ChangeMenu(Menu newMenu)
        {
            int i = menus.IndexOf(newMenu);
            if (i == currentlySelected) return;
            menus[currentlySelected].CloseMenu();
            menus[i].gameObject.SetActive(true);
            currentlySelected = i;
        }
    }
}