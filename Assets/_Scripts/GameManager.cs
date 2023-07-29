using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _levelPrefabs; 
	[SerializeField, Header("----- Just serialized for easy viewing in inspector -----")]
	private int _score;
	[SerializeField]
	private int _levelIndex;

	private GameObject _currentLevelInstance;

	public int Score { get { return _score; } set { _score = value; } }

    private void Start()
    {
		UILevelOver.OnNextLevel += NextLevel;
    }

    private void OnDisable()
    {
		UILevelOver.OnNextLevel -= NextLevel;
	}

	private void NextLevel()
    {
		if (_currentLevelInstance != null)
			Destroy(_currentLevelInstance);

		_levelIndex++;
		if (_levelIndex >= _levelPrefabs.Count)
        {
			// Go to end of game/high score screen.
        }
        else
        {
			// Load next level.
			Instantiate(_levelPrefabs[_levelIndex], Vector3.zero, Quaternion.identity);
        }
    }
}