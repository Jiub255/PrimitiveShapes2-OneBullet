using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Put this on Camera Focal Point
public class CameraMoveRotate : MonoBehaviour
{
    [SerializeField, Range(0f, 50f), Header("Keyboard Movement")]
    private float _movementSpeed = 20f;

    private Vector3 _forward;
    private Vector3 _right;
    private Vector3 _up;

    [SerializeField, Range(0f, 2f), Header("Rotate")]
    private float _rotationSpeed = 0.15f;
    [SerializeField, Range(0f, 40f)]
    private float _rotationXMin = 7f;
    [SerializeField, Range(50f, 90f)]
    private float _rotationXMax = 90f;

    private Transform _transform;
    private InputAction _zoomAction;
    private InputAction _rotateAction;
    private InputAction _moveAction;
    private InputAction _mouseDeltaAction;

    private void Start()
    {
        _transform = transform;
        _zoomAction = S.I.IM.C.FreeMove.Zoom;
        _rotateAction = S.I.IM.C.FreeMove.Rotate;
        _moveAction = S.I.IM.C.FreeMove.Move;
        _mouseDeltaAction = S.I.IM.C.FreeMove.MouseDelta;
    }

    private void LateUpdate()
    {
        // Zoom overrides everything else. Not noticeable since this action gets called only during
        // isolated frames, but it helps resolve some issues with moving while zooming.
        if (!_zoomAction.WasPerformedThisFrame())
        {
            GetVectors();

            Move();

//            if (_rotateAction.IsPressed())
            {
                RotateCamera();
            }
        }
    }

    private void GetVectors()
    {
        _forward = _transform.forward;
        _right = _transform.right;
        _up = Vector3.Cross(_forward, _right);
    }

    private void Move()
    {
        // Get input
        Vector3 keyboardInput = _moveAction.ReadValue<Vector3>();

        // Translate movement vector to world space
        Vector3 movement = (_forward * keyboardInput.z) + (_right * keyboardInput.x) + (_up * keyboardInput.y);

        // Move
        _transform.position += movement * _movementSpeed * Time.unscaledDeltaTime;
    }

    private void RotateCamera()
    {
        // Rotation around y-axis
        float deltaX = _mouseDeltaAction.ReadValue<Vector2>().x * _rotationSpeed;

        _transform.RotateAround(_transform.position, Vector3.up, deltaX);

        // Rotation around axis parallel to your local right vector, this axis always parallel to xz-plane.
        Vector3 axis = new Vector3(
            -Mathf.Cos(Mathf.Deg2Rad * _transform.rotation.eulerAngles.y),
            0f,
            Mathf.Sin(Mathf.Deg2Rad * _transform.rotation.eulerAngles.y));

        float deltaY = _mouseDeltaAction.ReadValue<Vector2>().y * _rotationSpeed;

        // Clamp x-rotation between min and max values (at most -90 to 90).
        if (_transform.rotation.eulerAngles.x - deltaY > _rotationXMin && _transform.rotation.eulerAngles.x - deltaY <= _rotationXMax)
        {
            _transform.RotateAround(_transform.position, axis, deltaY);
        }


/*        Vector2 mouseDelta = _mouseDeltaAction.ReadValue<Vector2>() * _rotationSpeed;
        float xRotation = 0f;
        // Only apply xRotation if it won't rotate camera out of allowed range. 
        if (_transform.rotation.x + mouseDelta.x <= _rotationXMax && _transform.rotation.x + mouseDelta.x >= _rotationXMin)
            xRotation = mouseDelta.x;
        float yRotation = mouseDelta.y;

        _transform.Rotate(new Vector3(xRotation, yRotation, 0f));*/
    }
}