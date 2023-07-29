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

	[SerializeField]
	private int _score;
    [SerializeField]
    private float _levelEndDelayTime;

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0f;
        OnHitTarget?.Invoke();
        StartCoroutine(EndLevel());
    }

    private IEnumerator EndLevel()
    {
        // Add score.
        S.I.GM.Score += _score;

        // Play hit animation/effects (particles?).
        yield return new WaitForSeconds(_levelEndDelayTime);

        // Show end of level score UI. 
        OnLevelOver?.Invoke(_score);

        // Load next level from UI button. 
    }
}