using UnityEngine;
using System.Collections;
using ElementStudio.Pivotal.Manager;

namespace ElementStudio.Pivotal
{
    public class CameraFollow : MonoBehaviour
    {
        public GravityPivotalController player;
        public Vector3 offset = new Vector3(0, 0, -10);
        public float timeToRotateCamera = 0.33f;
        private float rotationProgress, desiredRotation, startRotation, currentRotation;
        private bool rotationInProgress = false;

        void OnEnable()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<GravityPivotalController>();
            player.cam = this;
            timeToRotateCamera = PivotalManager.instance.settings.game.cameraTurnSpeed;
        }

        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }

        public void StartRotation()
        {
            if (rotationInProgress)
            {
                StopAllCoroutines();
                currentRotation = desiredRotation;
            }
            startRotation = currentRotation;
            desiredRotation = player.targetRotation;
            rotationProgress = 0f;
            rotationInProgress = true;
            StartCoroutine(RotationTick());
        }

        IEnumerator RotationTick()
        {
            while (rotationProgress <= timeToRotateCamera)
            {
                rotationProgress += Time.deltaTime;
                float percent = rotationProgress / timeToRotateCamera;
                currentRotation = Mathf.LerpAngle(startRotation, desiredRotation, percent);
                yield return new WaitForEndOfFrame();
            }
            currentRotation = desiredRotation;
            rotationInProgress = false;
        }
    }
}