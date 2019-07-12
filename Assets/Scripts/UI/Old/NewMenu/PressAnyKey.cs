using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace ElementStudio.Pivotal.Menu
{
    //Class specific for the Press Any Key text that appears on the game's start screen
    public class PressAnyKey : MonoBehaviour
    {
        [Tooltip("Controls the period of the modulation of alpha.")]
        public float alphaModulationPeriod = 1.0f;
        [Tooltip("Reference to the main menu MenuState.")]
        public MenuState menuStateToSwitchToOnAnyKey;
        //Reference to the renderer component
        private new TMP_Text renderer;
        public UnityEvent onPressAnyKey;

        void Awake()
        {
            //Gets our renderer.
            renderer = GetComponent<TMP_Text>();
        }

        void Update()
        {
            var tempColor = renderer.color;
            tempColor.a = Mathf.Abs(Mathf.Sin(Time.time * alphaModulationPeriod));
            renderer.color = tempColor;

            if (Input.anyKeyDown)
            {
                //We can start the menu now
                onPressAnyKey.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}