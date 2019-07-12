using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ElementStudio.Pivotal.Menu
{
    public class BackgroundColorRandomizer : MonoBehaviour
    {
        public List<Material> colors = new List<Material>();
        private Image cam;

        void OnEnable()
        {
            cam = GetComponent<Image>();
            int random = Random.Range(0, colors.Count);
            RenderSettings.skybox = colors[random];
        }
    }
}