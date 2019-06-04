using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ElementStudio.Pivotal
{
    public class ReplaySelect : MonoBehaviour
    {
        protected List<ReplayMenuOption> options = new List<ReplayMenuOption>();
        protected List<GameObject> levelObjects = new List<GameObject>();
        public GameObject replayChoicePrefab;
        public Transform replaySelectContainerTransform;

        void OnEnable()
        {
            //Populate our options, then create prefabs based on them
            PopulateReplayList();
            PopulateMenu();
        }

        void PopulateReplayList()
        {
            foreach (string file in Replay.GetReplayList())
            {
                options.Add(new ReplayMenuOption(file));
            }
        }

        void PopulateMenu()
        {
            foreach (ReplayMenuOption i in options)
            {
                GameObject selection = Instantiate(replayChoicePrefab, replaySelectContainerTransform.position, Quaternion.identity, replaySelectContainerTransform);
                selection.GetComponent<ReplayChoice>().SetLevelName(i.replayFileName);
                levelObjects.Add(selection);
            }
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

        public void ExitMenu()
        {
            Destroy(this.gameObject);
        }
    }

    [System.Serializable]
    public struct ReplayMenuOption
    {
        public string replayFileName;

        public ReplayMenuOption(string filename)
        {
            replayFileName = filename;
        }
    }
}