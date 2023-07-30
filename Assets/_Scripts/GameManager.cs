using LootLocker.Requests;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _levelPrefabs; 
	[SerializeField, Header("----- Just serialized for easy viewing in inspector -----")]
	private int _score;
	[SerializeField]
	private int _nextLevelIndex;

	private GameObject _currentLevelInstance;

	public int Score { get { return _score; } set { _score = value; } }
	public int NextLevelIndex { get { return _nextLevelIndex; } }
	public int LevelsCount { get { return _levelPrefabs.Count; } }	

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