using UnityEngine;

namespace ElementStudio.Pivotal
{
    //Base class for creating input
    public abstract class InputHandler : MonoBehaviour
    {
        public abstract bool Left();
        public abstract bool Right();
        public abstract bool Restart();
    }
}