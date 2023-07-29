using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 25f;

/*    [SerializeField]
    private ParticleSystem _hitParticleSystem;*/
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Target.OnHitTarget += HitTarget;
        Target.OnLevelOver += (_) => ResetBullet();
        CameraAim.OnShootBullet += Launch;
        UIHighScores.OnPlayAgain += ResetBullet;
    }

    private void OnDisable()
    {
        Target.OnHitTarget -= HitTarget;
        Target.OnLevelOver -= (_) => ResetBullet();
        CameraAim.OnShootBullet -= Launch;
        UIHighScores.OnPlayAgain -= ResetBullet;
    }

    private void Launch(Vector3 direction)
    {
        Vector3 launchVector = direction.normalized * _speed;

        _rigidbody.AddForce(launchVector, ForceMode.Impulse);
    }

    private void HitTarget()
    {
        Debug.Log("HitTarget");
//        _hitParticleSystem.Play();
        GetComponent<Renderer>().enabled = false;
        // Not sure if this is necessary. 
        _rigidbody.ResetInertiaTensor();
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void ResetBullet()
    {
        Debug.Log("ResetBullet");
        //        _hitParticleSystem.Stop();
        // Right behind camera, so it shoots where crosshair aims but doesn't get in the way of the camera while aiming. 
        transform.position = new Vector3(0f, 0f, -11f);
        GetComponent<Renderer>().enabled = true;
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        _hitParticleSystem.
    }*/
}