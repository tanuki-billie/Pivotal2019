using TMPro;
using UnityEngine;

namespace ElementStudio.Pivotal.UI
{
    public class VersionString : MonoBehaviour
    {
        void Awake()
        {
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = Manager.PivotalManager.gameVersion;
        }
    }
}