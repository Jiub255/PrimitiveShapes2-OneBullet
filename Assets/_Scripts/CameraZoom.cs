using UnityEngine;
using UnityEngine.InputSystem;

// Put this on Camera Leader
public class CameraZoom : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float _zoomSpeed = 2f;
    [SerializeField, Range(0f, 15f)]
    private float _zoomMinDist = 10f;
    [SerializeField, Range(16f, 255f)]
    private float _zoomMaxDist = 50f;
    [SerializeField, Range(5f, 35f)]
    private float _defaultZoomDist = 15f;

    private Transform _transform;
    private float _zoomLevel;

    private void Start()
    {
        _transform = transform;

        S.I.IM.C.FreeMove.Zoom.performed += Zoom;

        ZoomTo(_defaultZoomDist);
    }

    private void OnDisable()
    {
        S.I.IM.C.FreeMove.Zoom.performed -= Zoom;
    }

    private void ZoomTo(float zoomLevel)
    {
        _zoomLevel = zoomLevel;

        // Clamp zoom between min and max distances. 
        if (_zoomLevel < _zoomMinDist) 
            _zoomLevel = _zoomMinDist;
        if (_zoomLevel > _zoomMaxDist) 
            _zoomLevel = _zoomMaxDist;

        _transform.localPosition = new Vector3(0f, 0f, -zoomLevel);
    }
    
    private void Zoom(InputAction.CallbackContext context)
    {
        // Change zoom level based on mouse scroll wheel input. 
        ZoomTo(_zoomLevel - (context.ReadValue<float>() * _zoomSpeed));
    }
}