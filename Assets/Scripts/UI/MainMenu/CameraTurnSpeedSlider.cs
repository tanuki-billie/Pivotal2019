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
            _slider.value = PivotalManager.instance.cameraTurnSpeed;
        }

        public void DoChangeValue()
        {
            PivotalManager.instance.cameraTurnSpeed = _slider.value;
            PlayerPrefs.SetFloat("CameraTurnSpeed", _slider.value);
        }
    }
}