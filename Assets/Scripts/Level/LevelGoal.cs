using UnityEngine;

namespace ElementStudio.Pivotal
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LevelGoal : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                //It's time to end the level homeboy
                Level.instance.CompleteLevel();
            }
        }
    }
}