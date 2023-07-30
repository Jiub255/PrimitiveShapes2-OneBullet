using System;
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    /// <summary>
    /// Bullet listens, instantiates particle effects and disables it's mesh renderer. 
    /// </summary>
    public static event Action OnHitTarget;
    /// <summary>
    /// Level over UI listens, opens, pauses game?
    /// </summary>
    public static event Action<int> OnLevelOver;
    /// <summary>
    /// UI High score entry opens
    /// </summary>
    public static event Action<int> OnGameOver;

/*	[SerializeField]
	private int _score;*/
    [SerializeField]
    private float _levelEndDelayTime = 1f;
    [SerializeField]
    private Transform _targetCenter;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 contactPoint = collision.GetContact(0).point;
        float distanceFromCenter = Vector3.Distance(contactPoint, _targetCenter.position);

        Debug.Log("OnCollisionEnter with target");
        OnHitTarget?.Invoke();
        StartCoroutine(EndLevel(contactPoint, CalculateScore(distanceFromCenter)));
    }

    private int CalculateScore(float distanceFromCenter)
    {
        // Edge is 6 from center, so you get 1 - 7 points. 
        return Mathf.RoundToInt(7f - distanceFromCenter);
    }

    private IEnumerator EndLevel(Vector3 contactPoint, int score)
    {
        Debug.Log($"EndLevelCoroutine, adding {score} points from target with id {gameObject.GetInstanceID()}. ");
        // Add score.
        S.I.GM.Score += score;

        // Play hit animation/effects (primitive shape particles).
        // Use contactPoint. 


        yield return new WaitForSeconds(_levelEndDelayTime);

        Debug.Log($"Next level index: {S.I.GM.NextLevelIndex}, levels: {S.I.GM.LevelsCount}");
        if (S.I.GM.NextLevelIndex < S.I.GM.LevelsCount)
        {
            OnLevelOver?.Invoke(score);
        }
        else
        {
            OnGameOver?.Invoke(score);
        }
    }
}