using UnityEngine;
using ElementStudio.Pivotal.Levels;

namespace ElementStudio.Pivotal
{
    public class PlayerInputHandler : InputHandler
    {
        public override bool Left()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { }
            //    InputRecorder.instance.AddInput(InputType.Left, LevelPlayer.instance.levelTime);
            return Input.GetKeyDown(KeyCode.LeftArrow);
        }
        public override bool Right()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) { }
            //    InputRecorder.instance.AddInput(InputType.Right, LevelPlayer.instance.levelTime);
            return Input.GetKeyDown(KeyCode.RightArrow);
        }
        public override bool Restart()
        {
            return Input.GetKeyDown(KeyCode.R);
        }
    }
}