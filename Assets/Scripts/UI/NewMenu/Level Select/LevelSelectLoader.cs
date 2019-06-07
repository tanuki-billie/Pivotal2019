using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Menu
{
    public class LevelSelectLoader : MonoBehaviour
    {
        public List<LevelObject> availableLevels = new List<LevelObject>();
        public LevelInformationDisplay levelInformationDisplay;
        public GameObject levelSelectItemPrefab;
        UnityAction action;

        void OnEnable()
        {
            for (int i = 0; i < availableLevels.Count; i++)
            {
                GameObject item = Instantiate(levelSelectItemPrefab, Vector2.zero, Quaternion.identity, transform);
                item.GetComponent<LevelSelectChoice>().Setup(availableLevels[i]);
            }
        }
    }
}