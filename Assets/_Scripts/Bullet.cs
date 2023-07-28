using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _launchSpeed = 5f;

    private bool _aiming;
    private Vector2 _ballPosition;
    private InputAction _mousePositionAction;
    private Camera _camera;
    private Vector2 _aimDirection;
    private Transform _arrowBaseTransform;

    private void Start()
    {
        _aiming = true;
        _ballPosition = transform.position;
        _mousePositionAction = S.I.IM.C.Input.MousePosition;
        _camera = Camera.main;
        _arrowBaseTransform = transform.GetChild(0).transform;

        S.I.IM.C.Input.Click.canceled += (c) => Launch();
    }

    private void OnDisable()
    {
        S.I.IM.C.Input.Click.canceled -= (c) => Launch();
    }

    private void Update()
    {
        if (_aiming)
        {
            Vector2 mouseWorldPosition = _camera.ScreenToWorldPoint(_mousePositionAction.ReadValue<Vector2>());
            _aimDirection = (_ballPosition - mouseWorldPosition).normalized;
            Debug.Log($"Aiming direction: {_aimDirection}");
            Debug.Log($"Mouse position: {_mousePositionAction.ReadValue<Vector2>()}, Mouse world position: {mouseWorldPosition}");
            DrawAimingArrow();
        }
    }

    private void DrawAimingArrow()
    {
        // Draw arrow with base at center of bullet pointing in aiming direction. 
        float angle = CalculateAngle();
        _arrowBaseTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private float CalculateAngle()
    {
        // Do math to convert from Vector2 to angle. 
        if (_aimDirection.y >= 0f)
        {
            return Vector2.Angle(Vector2.right, _aimDirection);
        }
        else
        {
            return 360f - Vector2.Angle(Vector2.right, _aimDirection);
        }
    }

    public void Launch()
    {
        Debug.Log("Launch");
        _aiming = false;
        _arrowBaseTransform.gameObject.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().AddForce(_aimDirection * _launchSpeed, ForceMode2D.Impulse);
    }
}