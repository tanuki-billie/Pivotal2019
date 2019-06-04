using UnityEngine;
using UnityEngine.UI;

namespace ElementStudio.Pivotal
{
    public class ReplayChoice : MonoBehaviour
    {
        public Text replayNameDisplay;
        string filename;

        public void PlayReplay()
        {
            PivotalManager.instance.StartReplay(filename);
        }

        public void SetLevelName(string name)
        {
            filename = name;
            replayNameDisplay.text = filename;
        }
    }
}