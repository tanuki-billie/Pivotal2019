using UnityEngine;

namespace ElementStudio.Pivotal.Editor
{
    public class GameEditorCamera : MonoBehaviour
    {
        public float dragSpeed = 5.0f;
        Vector2 dragOrigin;
        Vector2 input;
        Camera cam;

        void Awake()
        {
            cam = GetComponent<Camera>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(1)) return;

            Vector2 pos = cam.ScreenToViewportPoint((Vector2)Input.mousePosition - dragOrigin);
            Vector2 move = new Vector2(pos.x * dragSpeed, pos.y * dragSpeed);
            transform.Translate(move, Space.World);
        }
    }
}