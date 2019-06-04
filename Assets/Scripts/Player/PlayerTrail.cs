using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ElementStudio.Pivotal
{
    public class PlayerTrail : MonoBehaviour
    {
        public Color trailColor = Color.white;
        public Sprite trailSprite;
        public int trailMaxCount = 12;
        public float trailFrequency = 6f;
        public float trailLifespan = 0.8f;

        List<GameObject> trailObjects = new List<GameObject>();
        GameObject emptyGameObject;
        float timer = 0;
        float trailPeriod;

        void Awake()
        {
            emptyGameObject = new GameObject("Player Trail");
            trailPeriod = 1 / trailFrequency;
            for (int i = 0; i < trailMaxCount; i++)
            {
                GameObject temp = Instantiate(emptyGameObject, Vector3.zero, Quaternion.identity);
                temp.AddComponent<SpriteRenderer>();
                temp.GetComponent<SpriteRenderer>().sprite = trailSprite;
                temp.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                temp.GetComponent<SpriteRenderer>().color = trailColor;
                temp.SetActive(false);
                trailObjects.Add(temp);
            }
            Destroy(emptyGameObject);
        }

        void Update()
        {
            if (Level.instance.currentLevelState == LevelState.Playing)
            {
                timer += Time.deltaTime;
                if (timer >= trailPeriod)
                {
                    timer = 0;
                    GameObject newTrail = GetTrail();
                    if (newTrail != null)
                    {
                        DoTrail(newTrail);
                    }
                }
            }

        }

        private GameObject GetTrail()
        {
            for (int i = 0; i < trailMaxCount; i++)
            {
                if (!trailObjects[i].activeInHierarchy)
                {
                    return trailObjects[i];
                }
            }
            return null;
        }

        private void DoTrail(GameObject trailObject)
        {
            trailObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            trailObject.SetActive(true);
            StartCoroutine(DoTrialEnd(trailObject));
        }

        private IEnumerator DoTrialEnd(GameObject trailObject)
        {
            yield return new WaitForSeconds(trailLifespan);
            trailObject.SetActive(false);
        }
    }
}