using UnityEngine;

// Put this on Camera Follower
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _follow;
    [SerializeField, Range(0.1f, 1.0f)]
    private float _smoothTime = 0.3f;
/*    [SerializeField]
    private float _maxSpeed = 25f;*/

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _velocity2 = Vector3.zero;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Vector3.Distance(_transform.position, _follow.position) < 0.2f)
        {
            _transform.position = Vector3.SmoothDamp(
                _transform.position,
                _follow.position,
                ref _velocity,
                _smoothTime,
                Mathf.Infinity/*_maxSpeed*/,
                Time.unscaledDeltaTime);
        }

        _transform.rotation = Quaternion.Euler(Vector3.SmoothDamp(
            _transform.rotation.eulerAngles,
            _follow.rotation.eulerAngles,
            ref _velocity2,
            _smoothTime,
            Mathf.Infinity,
            Time.unscaledDeltaTime));
    }
}