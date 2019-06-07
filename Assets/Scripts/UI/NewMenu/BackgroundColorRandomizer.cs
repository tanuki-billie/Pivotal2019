using UnityEngine;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Menu
{
    public class BackgroundColorRandomizer : MonoBehaviour
    {
        public List<Color> colors = new List<Color>();
        private Camera cam;

        void OnEnable()
        {
            cam = GetComponent<Camera>();
            int random = Random.Range(0, colors.Count);
            cam.backgroundColor = colors[random];
        }
    }
}