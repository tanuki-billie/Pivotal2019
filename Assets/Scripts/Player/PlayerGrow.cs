using UnityEngine;
using DG.Tweening;

namespace ElementStudio.Pivotal
{
    public class PlayerGrow : MonoBehaviour
    {
        Vector3 startSize = new Vector3(0.01f, 0.01f, 1f);
        Vector3 endSize = Vector3.one;
        public float timeToGrow = 2.0f;

        void OnEnable()
        {
            Debug.Log("Player has been spawned. It's grow time.");
            transform.localScale = startSize;
            transform.DOScale(Vector3.one, timeToGrow);
        }
    }
}