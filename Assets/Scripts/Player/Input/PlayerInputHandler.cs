using UnityEngine;

namespace ElementStudio.Pivotal
{
    public class PlayerInputHandler : InputHandler
    {
        public override bool Left()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                InputRecorder.instance.AddInput(InputType.Left, Level.instance.currentTiming);
            return Input.GetKeyDown(KeyCode.LeftArrow);
        }
        public override bool Right()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                InputRecorder.instance.AddInput(InputType.Right, Level.instance.currentTiming);
            return Input.GetKeyDown(KeyCode.RightArrow);
        }
        public override bool Restart()
        {
            return Input.GetKeyDown(KeyCode.R);
        }
    }
}