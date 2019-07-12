using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Menu
{
    public class BackgroundColorRandomizer : MonoBehaviour
    {
        public List<Color> colors = new List<Color>();
        private Image cam;

        void OnEnable()
        {
            cam = GetComponent<Image>();
            int random = Random.Range(0, colors.Count);
            cam.color = colors[random];
        }
    }
}