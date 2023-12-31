using UnityEngine;

public class SkyboxCamera : MonoBehaviour
{
	[SerializeField]
	private Transform _mainCameraTransform;
    private Transform _transform;

    public Transform MainCameraTransform { get { return _mainCameraTransform; } set { _mainCameraTransform = value; } }

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.rotation = _mainCameraTransform.rotation;
    }
}