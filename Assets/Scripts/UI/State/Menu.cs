using UnityEngine;

namespace ElementStudio.Pivotal.UI
{
    //Class to define a menu and what state it is in.
    public class Menu : MonoBehaviour
    {
        //We need to keep track of our own animator so we can close.
        private Animator _animator;
        public bool open { get; private set; }

        public void OnEnable()
        {
            OpenMenu();
        }

        public void OpenMenu()
        {
            _animator.SetTrigger(Animator.StringToHash("Open"));
            open = true;
        }

        public void CloseMenu()
        {
            Debug.Log("Close signal received");
            _animator.SetTrigger(Animator.StringToHash("Close"));
            open = false;
            //gameObject.SetActive(false);
        }

        public void OnDisable()
        {
            Debug.Log("Disabled signal received.");
            gameObject.SetActive(false);
        }

        public void DoCleanup()
        {
            Debug.Log("Cleanup signal received.");
            gameObject.SetActive(false);
        }

        void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}