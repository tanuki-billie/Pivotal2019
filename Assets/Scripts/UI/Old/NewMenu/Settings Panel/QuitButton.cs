using UnityEngine;

namespace ElementStudio.Pivotal.Menu
{
    public class QuitButton : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}