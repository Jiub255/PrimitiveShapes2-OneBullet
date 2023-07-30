using LootLocker.Requests;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static event System.Action OnWin;
	public static event System.Action OnNextLevel;

	[SerializeField]
	private List<GameObject> _levelPrefabs; 
	[SerializeField, Header("----- Just serialized for easy viewing in inspector -----")]
	private int _score;
	[SerializeField]
	private int _nextLevelIndex;
	[SerializeField]
	private int _enemiesHit;

	private GameObject _currentLevelInstance;

	public int Score { get { return _score; } set { _score = value; } }
	public int NextLevelIndex { get { return _nextLevelIndex; } }
	public int LevelsCount { get { return _levelPrefabs.Count; } }	
	public int EnemiesHit 
	{ 
		get 
		{ 
			return _enemiesHit;
		} 
		set 
		{ 
			_enemiesHit = value;
			if (_enemiesHit > _nextLevelIndex)
            {
				if (_nextLevelIndex < _levelPrefabs.Count)
                {
					NextLevel();
                }
                else
                {
					// Add 1 to score. 
					_score++;
					// Go to win screen. 
					OnWin?.Invoke();
                }
            }
		}
	}

    private void Start()
    {
		LootLockerSDKManager.StartGuestSession((response) =>
		{
			if (!response.success)
			{
				Debug.LogWarning("Error starting lootlocker session. ");
				return;
			}

			Debug.Log("Successfully started lootlocker session. ");
		});

		UINextLevel.OnNextLevel += NextLevel;
		UIHighScores.OnPlayAgain += PlayAgain;
    }

    private void OnDisable()
    {
		UINextLevel.OnNextLevel -= NextLevel;
		UIHighScores.OnPlayAgain -= PlayAgain;
	}

	private void NextLevel()
    {
		Debug.Log($"Next level. Current level instance null: {_currentLevelInstance == null}");

		// Reset "enemies hit" counter. 
		_enemiesHit = 0;

		// Add 1 to score.
		_score++;

		OnNextLevel?.Invoke();

		if (_currentLevelInstance != null)
        {
			Debug.Log("About to destroy current level instance.");
			Destroy(_currentLevelInstance);
        }

		// Load next level.
		_currentLevelInstance = Instantiate(_levelPrefabs[_nextLevelIndex], Vector3.zero, Quaternion.identity);

		// Increment index after instantiating so first level can be index zero. 
		_nextLevelIndex++;
    }

	private void PlayAgain()
    {
		_score = 0;
        _nextLevelIndex = 0;
		NextLevel();
    }
}