using UnityEngine;
using System.Collections.Generic;

namespace ElementStudio.Pivotal
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField]
        public List<LevelObject> levelsToSelect = new List<LevelObject>();
        protected List<GameObject> levelObjects = new List<GameObject>();
        public GameObject levelSelectPrefab;
        public Transform levelSelectLayoutParent;

        void OnEnable()
        {
            foreach (LevelObject i in levelsToSelect)
            {
                //Iterate through each and create a new prefab
                GameObject option = Instantiate(levelSelectPrefab, levelSelectLayoutParent.position, Quaternion.identity, levelSelectLayoutParent);
                LevelRecord record = LevelRecord.Load(i.internalName, false, i.author);
                option.GetComponent<LevelChoice>().SetChoice(i.levelTitle, record.recordTime, i.buildIndex);
                levelObjects.Add(option);
            }
        }

        public void ExitMenu()
        {
            Destroy(this.gameObject);
        }

        void OnDisable()
        {
            //Clean up memory
            for (int i = 0; i < levelObjects.Count; i++)
            {
                Destroy(levelObjects[i]);
                levelObjects.RemoveAt(i);
            }
        }
    }
}