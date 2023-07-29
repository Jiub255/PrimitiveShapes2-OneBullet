using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

/*    [SerializeField]
    private ParticleSystem _hitParticleSystem;*/
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Target.OnHitTarget += HitTarget;
        Target.OnLevelOver += (_) => ResetBullet();
        CameraAim.OnShootBullet += Launch;
    }

    private void OnDisable()
    {
        Target.OnHitTarget -= HitTarget;
        Target.OnLevelOver -= (_) => ResetBullet();
        CameraAim.OnShootBullet -= Launch;
    }

    private void Launch(Vector3 direction)
    {
        Vector3 launchVector = direction.normalized * _speed;

        _rigidbody.AddForce(launchVector, ForceMode.Impulse);
    }

    private void HitTarget()
    {
//        _hitParticleSystem.Play();
        GetComponent<Renderer>().enabled = false;
    }

    private void ResetBullet()
    {
//        _hitParticleSystem.Stop();
        // Not sure if this is necessary. 
        _rigidbody.ResetInertiaTensor();
        // Right in front of camera. 
        transform.position = new Vector3(0f, -0.8f, -9f);
        GetComponent<Renderer>().enabled = true;
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        _hitParticleSystem.
    }*/
}