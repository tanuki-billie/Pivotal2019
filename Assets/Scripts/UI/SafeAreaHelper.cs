using UnityEngine;
using UnityEngine.UI;
namespace ElementStudio.Pivotal.UI
{
    //Class to help with safe areas on screens.
    public class SafeAreaHelper : MonoBehaviour
    {
        RectTransform panel; //Our panel to resize.
        Rect lastSafeArea = new Rect(0, 0, 0, 0);

        void Awake()
        {
            panel = GetComponent<RectTransform>();
            Refresh();
        }

        void Update()
        {
            Refresh();
        }

        void Refresh()
        {
            Rect safeArea = Screen.safeArea;

            if (safeArea != lastSafeArea)
            {
                ApplySafeArea(safeArea);
            }
        }

        void ApplySafeArea(Rect r)
        {
            Vector2 anchorMin = r.position;
            Vector2 anchorMax = r.position + r.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            panel.anchorMin = anchorMin;
            panel.anchorMax = anchorMax;
        }

    }
}
