using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ElementStudio.Pivotal.Menu
{
    public class LevelSelectChoice : MonoBehaviour
    {
        public LevelObject objectToPass { set; private get; }
        public TMP_Text titleText;
        public TMP_Text recordText;
        public Button self;

        void OnEnable()
        {
            self = GetComponent<Button>();
        }

        public void Setup(LevelObject level)
        {
            objectToPass = level;
            titleText.text = objectToPass.levelTitle;
            LevelRecord record = LevelRecord.Load(objectToPass.internalName, false, objectToPass.author);
            if (float.IsNaN(record.recordTime))
            {
                recordText.gameObject.SetActive(false);
            }
            else
            {
                recordText.text = string.Format("Your record: {0:00}:{1:00}.{2:00}", Mathf.Floor(record.recordTime / 60), Mathf.Floor(record.recordTime % 60), (record.recordTime - Mathf.Floor(record.recordTime)) * 100);
            }
        }

        public void SelectLevel()
        {
            LevelInformationDisplay.instance.UpdateCanvas(objectToPass);
        }
    }
}