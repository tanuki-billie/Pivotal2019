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
            GetAnimator();
            OpenMenu();
        }

        public void OpenMenu()
        {
            if (_animator == null) GetAnimator();
            _animator.SetTrigger(Animator.StringToHash("Open"));
            open = true;
        }

        public void CloseMenu()
        {
            if (_animator == null) GetAnimator();
            _animator.SetTrigger(Animator.StringToHash("Close"));
            open = false;
            //gameObject.SetActive(false);
        }

        public void OnDisable()
        {
            gameObject.SetActive(false);
        }

        public void DoCleanup()
        {
            gameObject.SetActive(false);
        }

        void Awake()
        {
            GetAnimator();
        }

        void GetAnimator()
        {
            _animator = GetComponent<Animator>();
        }
    }
}