using UnityEngine;

public class Sun : MonoBehaviour
{
	[SerializeField]
	private Transform _skyboxCameraTransform;

    private void Start()
    {
        transform.LookAt(_skyboxCameraTransform);
    }
}