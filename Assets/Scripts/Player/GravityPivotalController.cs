using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Prime31;

namespace ElementStudio.Pivotal
{
    [RequireComponent(typeof(CharacterController2D))]
    public class GravityPivotalController : MonoBehaviour
    {
        private CharacterController2D _characterController;
        private InputHandler _inputHandler;
        private float _currentVelocity;
        private Vector2 _localVelocity;
        //If false, we are moving; if true, we are changing direction
        private bool _isChangingDirection = false;
        //Progress towards our current rotation, should be a value from 0 to rotationTime.
        private float _rotationProgress = 0f;
        private bool _grounded
        {
            get
            {
                switch (currentGravityDirection)
                {
                    case GravityDirection.Up:
                        return _characterController.collisionState.above;
                    case GravityDirection.Down:
                        return _characterController.collisionState.below;
                    case GravityDirection.Left:
                        return _characterController.collisionState.left;
                    case GravityDirection.Right:
                        return _characterController.collisionState.right;
                    default:
                        return false;
                }
            }
        }
        private float originalRotation = 0f;
        private float targetRotation = 0f;

        //Our current direction. Defaults to down.
        public GravityDirection currentGravityDirection = GravityDirection.Down;
        //Acceleration due to gravity.
        public float gravitySpeed = 9.8f;
        //Terminal velocity of the character.
        public float terminalVelocity = 50f;
        //Time it takes for the character to fully rotate.
        public float rotationTime = 0.05f;
        //The layer mask for collisions
        public LayerMask groundCollisionMask;
        //The point at which ground collisions happen
        public Vector2 _groundCollisionPosition;

        void Awake()
        {
            _characterController = GetComponent<CharacterController2D>();
            _inputHandler = GetComponent<InputHandler>();
            SetupGravity();
        }

        void Update()
        {
            if (!_isChangingDirection)
            {
                if (_inputHandler.Left())
                {
                    StartRotation(-1);
                }
                else if (_inputHandler.Right())
                {
                    StartRotation(1);
                }
                if (!_grounded)
                {
                    _currentVelocity += gravitySpeed * Time.deltaTime;
                    if (_currentVelocity < terminalVelocity) _currentVelocity = terminalVelocity;
                }
                else
                {
                    _currentVelocity = 0;
                }
                _localVelocity = new Vector2(0, _currentVelocity);
                _characterController.move(SetVelocityDirection(_localVelocity));
            }
            else
            {
                if (_rotationProgress >= rotationTime)
                {
                    StopRotation();
                }
                _rotationProgress += Time.deltaTime;
                float newAngle = Mathf.LerpAngle(originalRotation, targetRotation, _rotationProgress / rotationTime);
                transform.localRotation = Quaternion.Euler(0, 0, newAngle);
            }
            if (_inputHandler.Restart())
            {
                Scene current = SceneManager.GetActiveScene();
                SceneManager.LoadScene(current.buildIndex);
            }
        }

        void SetupGravity()
        {
            if (gravitySpeed > 0) gravitySpeed = -gravitySpeed;
            if (terminalVelocity > 0) terminalVelocity = -terminalVelocity;
            Debug.Log("Gravity variables have been set up to be negative!");
        }

        Vector2 SetVelocityDirection(Vector2 input)
        {
            switch (currentGravityDirection)
            {
                case GravityDirection.Up:
                    return new Vector2(-input.x, -input.y);
                case GravityDirection.Down:
                    return input;
                case GravityDirection.Left:
                    return new Vector2(input.y, -input.x);
                case GravityDirection.Right:
                    return new Vector2(-input.y, input.x);
                default:
                    return input;
            }
        }

        void StartRotation(float inputDirection)
        {
            _rotationProgress = 0;
            inputDirection = Mathf.Sign(inputDirection);
            GetGravityDirectionOnRotate(inputDirection);
            _currentVelocity /= 2;
            originalRotation = transform.localEulerAngles.z;
            targetRotation = originalRotation + inputDirection * 90;
            _isChangingDirection = true;
        }

        void GetGravityDirectionOnRotate(float inputDirection)
        {
            inputDirection = Mathf.Sign(inputDirection);
            switch (currentGravityDirection)
            {
                case GravityDirection.Down:
                    currentGravityDirection = (inputDirection > 0) ? GravityDirection.Right : GravityDirection.Left;
                    break;
                case GravityDirection.Up:
                    currentGravityDirection = (inputDirection < 0) ? GravityDirection.Right : GravityDirection.Left;
                    break;
                case GravityDirection.Left:
                    currentGravityDirection = (inputDirection > 0) ? GravityDirection.Down : GravityDirection.Up;
                    break;
                case GravityDirection.Right:
                    currentGravityDirection = (inputDirection < 0) ? GravityDirection.Down : GravityDirection.Up;
                    break;
                default:
                    currentGravityDirection = GravityDirection.Down;
                    break;
            }
        }

        void StopRotation()
        {
            transform.localRotation = Quaternion.Euler(0, 0, targetRotation);
            _isChangingDirection = false;
        }
    }

    public enum GravityDirection
    {
        Down = 0,
        Right = 90,
        Up = 180,
        Left = 270
    }
}