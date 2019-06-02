using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ElementStudio.Pivotal
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;
        public DialogBox currentDialogBox;
        public GameObject firstFocus;
        public EventSystem eventSystem;

        void Awake()
        {
            if (instance != null) Destroy(this.gameObject);
            instance = this;
            Debug.Log("Menu Manager initialized.");
            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            eventSystem.SetSelectedGameObject(firstFocus);
        }

        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }

        public void OpenDialog(GameObject dialogPrefab)
        {
            if (currentDialogBox != null) return;
            currentDialogBox = Instantiate(dialogPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<DialogBox>();
        }

        public void Quit()
        {
            Application.Quit(0);
        }

        public void OnApplicaionQuit()
        {
            //This is where we would do stuff like make sure everything is saved!
        }
    }
}