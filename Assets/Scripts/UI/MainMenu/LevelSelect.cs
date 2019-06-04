using UnityEngine;
using System.Collections.Generic;

namespace ElementStudio.Pivotal
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField]
        public List<LevelSelectOption> levelsToSelect = new List<LevelSelectOption>();
        protected List<GameObject> levelObjects = new List<GameObject>();
        public GameObject levelSelectPrefab;
        public Transform levelSelectLayoutParent;

        void OnEnable()
        {
            foreach (LevelSelectOption i in levelsToSelect)
            {
                //Iterate through each and create a new prefab
                GameObject option = Instantiate(levelSelectPrefab, levelSelectLayoutParent.position, Quaternion.identity, levelSelectLayoutParent);
                option.GetComponent<LevelChoice>().SetLevelName(i.levelName, i.buildIndex);
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

    [System.Serializable]
    public struct LevelSelectOption
    {
        public string levelName;
        public int buildIndex;

        public LevelSelectOption(string name, int index)
        {
            levelName = name;
            buildIndex = index;
        }
    }
}