using UnityEngine.UI;
using UnityEngine;

namespace ElementStudio.Pivotal
{
    public class CameraTurnSpeedSlider : MonoBehaviour
    {
        private Slider _slider;
        void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(delegate { DoChangeValue(); });

        }
        void Start()
        {
            _slider.value = Manager.PivotalManager.instance.settings.game.cameraTurnSpeed;
        }

        public void DoChangeValue()
        {
            Manager.PivotalManager.instance.settings.game.cameraTurnSpeed = _slider.value;
        }
    }
}