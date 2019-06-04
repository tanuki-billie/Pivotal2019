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
        public List<RecordInput> inputsRecorded = new List<RecordInput>();
        [NonSerialized]
        public static InputRecorder instance;

        void Awake()
        {
            if (instance != null) Destroy(this);
            instance = this;
        }

        public void AddInput(InputType input, float timestamp)
        {
            RecordInput i = new RecordInput(timestamp, input);
            inputsRecorded.Add(i);
        }

        public void SaveInputs()
        {
            Replay r = new Replay(inputsRecorded, SceneManager.GetActiveScene().buildIndex);
            r.Save(DateTime.Now.ToString("yyyy-MM-dd hh_mm_ss tt"));
        }
    }
    [Serializable]
    public struct RecordInput
    {
        public float timestamp;
        public InputType input;

        public RecordInput(float timestamp, InputType input)
        {
            this.timestamp = timestamp;
            this.input = input;
        }
    }
    public enum InputType
    {
        Left,
        Right
    }
}