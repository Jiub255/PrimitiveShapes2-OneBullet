using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _follow;
/*    [SerializeField]
    private Transform _lookAt;*/
    [SerializeField]
    private float _smoothTime = 0.3f;
    [SerializeField]
    private float _trailingDistance = 5f;

    /// <summary>
    /// Leave variable alone, used by SmoothDamp. 
    /// </summary>
    private Vector3 _smoothDampVelocity = Vector3.zero;
    private Transform _transform;

    private bool _following; 

    /*    [SerializeField]
        private float _maxSpeed = 25f;*/

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        CameraAim.OnShootBullet += (_) => _following = true;
        Target.OnLevelOver += (_) => _following = false;
        Target.OnGameOver += (_) => _following = false;
        UINextLevel.OnNextLevel += ResetCamera;
        UIHighScores.OnPlayAgain += ResetCamera;
    }

    private void OnDisable()
    {
        CameraAim.OnShootBullet -= (_) => _following = true;
        Target.OnLevelOver -= (_) => _following = false;
        Target.OnGameOver -= (_) => _following = false;
        UINextLevel.OnNextLevel -= ResetCamera;
        UIHighScores.OnPlayAgain -= ResetCamera;
    }

    private void Update()
    {
        if (_following)
        {
            MoveTowardsBullet();
            LookAtBullet();
        }
    }

    private void ResetCamera()
    {
        _following = false;
        _transform.position = new Vector3(0f, 0f, -10f);
        _transform.rotation = Quaternion.identity;
    }

    private void MoveTowardsBullet()
    {
        _transform.position = Vector3.SmoothDamp(
            _transform.position,
            _follow.position + GetOffset(),
            ref _smoothDampVelocity,
            _smoothTime,
            /*_maxSpeed*/Mathf.Infinity,
            Time.unscaledDeltaTime);
    }

    private void LookAtBullet()
    {
        _transform.LookAt(_follow);
    }

    /// <summary>
    /// Offset follow point by camera's back vector * trailing distance. 
    /// Don't use bullet's back vector because camera would turn away from bullet when it bounced. 
    /// </summary>
    /// <returns></returns>
    private Vector3 GetOffset()
    {
        Vector3 offset = _transform.TransformDirection(_transform.forward * -1);
        offset.Normalize();
        offset *= _trailingDistance;
        return offset;
    }
}