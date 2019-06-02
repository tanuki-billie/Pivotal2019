using UnityEngine;

namespace ElementStudio.Pivotal
{
    public class CameraFollow : MonoBehaviour
    {
        public GravityPivotalController player;
        public Vector3 offset = new Vector3(0, 0, -10);

        void OnEnable()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<GravityPivotalController>();
        }

        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
            transform.rotation = player.transform.rotation;
        }
    }
}