using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Transform[] _waypoints;
	[SerializeField]
	private float _speed = 5f;
	private int _waypointIndex;
	private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        S.I.GM.EnemiesHit++;
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 direction = (_waypoints[_waypointIndex].position - _transform.position).normalized;

        _transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(_transform.position, _waypoints[_waypointIndex].position) < 0.1f)
        {
            _waypointIndex++;
            if (_waypointIndex >= _waypoints.Length) 
                _waypointIndex = 0;
        }
    }
}