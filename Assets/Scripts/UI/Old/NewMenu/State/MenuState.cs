using UnityEngine;
using UnityEngine.UI;

namespace ElementStudio.Pivotal.Menu
{
    public class MenuState : MonoBehaviour
    {
        private Animator _animator;
        private CanvasGroup _canvasGroup;
        [HideInInspector]
        public bool isOpen = false;
        const string closeMenuTrigger = "menuClose";
        const string openMenuTrigger = "menuOpen";

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        public void OpenMenu()
        {
            _animator.SetTrigger(Animator.StringToHash(openMenuTrigger));
            isOpen = true;
        }
        public void CloseMenu()
        {
            _animator.SetTrigger(Animator.StringToHash(closeMenuTrigger));
            isOpen = false;
        }
    }
}