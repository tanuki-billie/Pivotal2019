using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.IO;

namespace ElementStudio.Pivotal
{
    [Serializable]
    public class InputRecorder : MonoBehaviour
    {
        public List<ReplayInputRecording> inputsRecorded = new List<ReplayInputRecording>();
        [NonSerialized]
        public static InputRecorder instance;

        void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }

        public void AddInput(InputType input, float timestamp, Vector2 position, GravityDirection orientation, float velocity)
        {
            ReplayInputRecording i = new ReplayInputRecording(timestamp, input, position, orientation, velocity);
            inputsRecorded.Add(i);
        }

        public void SaveInputs(string appendix = "")
        {
            Replay r = new Replay(inputsRecorded, Levels.LevelManager.instance.level.uuid);
            r.Save(r.level + DateTime.Now.ToString("yyyy-MM-ddHH_mm") + appendix);
        }
    }

    public enum InputType
    {
        Left,
        Right
    }
}