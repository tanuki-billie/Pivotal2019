using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ElementStudio.Pivotal
{
    public class DialogBox : MonoBehaviour
    {
        [Header("GameObjects")]
        public Button okButton;
        public Button cancelButton;

        [Header("Events")]
        public UnityEvent onOk;
        public UnityEvent onCancel;

        //Other things we might need
        private EventSystem _eventSystem;
        private GameObject lastSelectedBeforeDialogOpened;

        //Functions
        void OnEnable()
        {
            _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            lastSelectedBeforeDialogOpened = _eventSystem.currentSelectedGameObject;
            _eventSystem.SetSelectedGameObject(cancelButton.gameObject);
        }
        public void Ok()
        {
            onOk.Invoke();
        }

        public void Cancel()
        {
            onCancel.Invoke();
            //Destroy me!
            //TODO: Probably adjust this to work outside of the main menu
            MenuManager.instance.currentDialogBox = null;
            _eventSystem.SetSelectedGameObject(lastSelectedBeforeDialogOpened);
            Destroy(this.gameObject);
        }
    }
}