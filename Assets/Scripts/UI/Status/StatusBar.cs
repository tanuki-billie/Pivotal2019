using UnityEngine;
using TMPro;

namespace ElementStudio.Pivotal.UI
{
    public class StatusBar : MonoBehaviour
    {
        public TMP_Text timeText;
        public TMP_Text batteryText;
        bool showBattery = true;

        void Awake()
        {
            Debug.Log(SystemInfo.batteryStatus);
            if (SystemInfo.batteryStatus == BatteryStatus.Unknown || SystemInfo.batteryLevel < 0f)
            {
                showBattery = false;
                batteryText.enabled = false;
            }
        }

        void Update()
        {
            timeText.text = System.DateTime.Now.ToShortTimeString();
            if (showBattery)
            {
                batteryText.text = string.Format("{0}%", SystemInfo.batteryLevel * 100);
            }
        }
    }
}