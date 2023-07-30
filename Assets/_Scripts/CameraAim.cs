using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAim : MonoBehaviour
{
    /// <summary>
    /// CameraFollow listens, starts following bullet. <br/>
    /// Bullet listens, launches in camera's forward direction. 
    /// </summary>
    public static event Action<Vector3> OnShootBullet;

    [SerializeField]
    private Vector2 _yRotationMinMax;
    [SerializeField]
    private Vector2 _xRotationMinMax;

    private InputAction _mousePositionAction;
    private Transform _transform;
    private float _yRange;
    private float _xRange;
    private bool _aiming;

    private void Start()
    {
        _mousePositionAction = S.I.IM.C.Input.MousePosition;
        _transform = transform;
        _yRange = _yRotationMinMax.y - _yRotationMinMax.x;
        _xRange = _xRotationMinMax.y - _xRotationMinMax.x;

        S.I.IM.C.Game.Click.canceled += Launch;
        UINextLevel.OnNextLevel += () => _aiming = true;
        UIHighScores.OnPlayAgain += () => _aiming = true;
    }

    private void OnDisable()
    {
        S.I.IM.C.Game.Click.canceled -= Launch;
        UINextLevel.OnNextLevel -= () => _aiming = true;
        UIHighScores.OnPlayAgain -= () => _aiming = true;
    }

    private void Launch(InputAction.CallbackContext _)
    {
        if (_aiming)
        {
            _aiming = false;
            OnShootBullet?.Invoke(_transform.forward);
        }
    }

    private void Update()
    {
//        Debug.Log($"Mouse position: {_mousePositionAction.ReadValue<Vector2>()}, Screen size: {Screen.height} x {Screen.width}");

        if (_aiming)
        {
            Vector2 mousePosition = _mousePositionAction.ReadValue<Vector2>();

            // Scale mouse position to have coordinates in [0, 1]. 
            Vector2 scaledMousePosition = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);

            SetAimAngle(scaledMousePosition);
        }
    }

    private void SetAimAngle(Vector2 scaledMousePosition)
    {
        // Scale mousePosition again to be between y rotation min and max. 
        float y = scaledMousePosition.x * _yRange + _yRotationMinMax.x;
        // Scale mousePosition again to be between x rotation min and max. 
        float x = scaledMousePosition.y * _xRange + _xRotationMinMax.x;

        _transform.rotation = Quaternion.Euler(-x, y, 0);
    }
}