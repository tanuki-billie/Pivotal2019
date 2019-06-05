using UnityEngine;

namespace ElementStudio.Pivotal
{
    public class ReplayInputHandler : InputHandler
    {
        private Replay currentReplay;
        private int replayNextInput = 0;
        private bool left, right, isPlaying;

        public void SetReplay(Replay replay)
        {
            currentReplay = replay;
        }

        public void StartPlaying()
        {
            isPlaying = true;
        }

        void Update()
        {
            if (!Level.instance.isPaused)
            {
                left = right = false;
                if (replayNextInput >= currentReplay.recordedInputs.Count) return;
                if (isPlaying)
                {
                    float time = Level.instance.currentTiming;
                    if (time >= currentReplay.recordedInputs[replayNextInput].timestamp)
                    {
                        if (currentReplay.recordedInputs[replayNextInput].input == InputType.Left)
                        {
                            left = true;
                        }
                        else
                        {
                            right = true;
                        }
                        replayNextInput++;
                    }
                }
            }
        }

        public override bool Restart()
        {
            //We never want to restart during a replay, so we will always return true.
            return false;
        }

        public override bool Left()
        {
            return left;
        }

        public override bool Right()
        {
            return right;
        }
    }
}