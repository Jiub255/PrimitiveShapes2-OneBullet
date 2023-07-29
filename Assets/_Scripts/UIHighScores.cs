using LootLocker.Requests;
using System;
using UnityEngine;

public class UIHighScores : MonoBehaviour
{
	/// <summary>
	/// Reset ball, reset level index, destroy last level, instantiate first level, reset score, reset camera. 
	/// </summary>
	public static event Action OnPlayAgain;

	[SerializeField]
	private GameObject _leaderboardCanvas;
	[SerializeField]
	private GameObject _highScoreEntryPrefab;
	[SerializeField]
	private Transform _entryParent;

	private string _leaderboardKey = "highscores";

    private void Start()
    {
		UIHighScoreEntry.OnSubmitScore += SetupUI;
    }

    private void OnDisable()
    {
        UIHighScoreEntry.OnSubmitScore -= SetupUI;
    }

    private void SetupUI()
	{
		_leaderboardCanvas.SetActive(true);

		foreach (Transform scoreEntry in _entryParent)
		{
			Destroy(scoreEntry.gameObject);
		}

		LootLockerSDKManager.GetScoreList(_leaderboardKey, 10, (response) =>
		{
			if (response.success)
			{
				// Need to sort or not? 
				LootLockerLeaderboardMember[] scores = response.items;

				foreach (LootLockerLeaderboardMember score in scores)
				{
					SetupHighScoreEntry(score);
				}
			}
			else
			{
				Debug.LogWarning($"Failed to get score list: {response.Error}");
			}
		});
	}

	private void SetupHighScoreEntry(LootLockerLeaderboardMember leaderboardMember)
	{
		GameObject entry = Instantiate(_highScoreEntryPrefab, _entryParent);

		string name = leaderboardMember.metadata;

		// Truncate string and add ... if over 30 characters, so it doesn't mess up leaderboard UI. 
		// Maybe base size off screen size somehow instead? This might not work for small screens. 
		if (name.Length > 30)
		{
			name = name.Substring(0, 27) + "...";
		}

		entry.GetComponent<HighScoreEntry>().SetupEntry(
			leaderboardMember.rank.ToString(),
			name,
			leaderboardMember.score.ToString());
	}

	public void PlayAgain()
    {
		_leaderboardCanvas.SetActive(false);
		OnPlayAgain?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }
}