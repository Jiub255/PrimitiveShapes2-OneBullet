using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class TESTLeaderboard : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _nameInputField;
	[SerializeField]
	private TMP_InputField _scoreInputField;
	[SerializeField]
	private GameObject _highScoreEntryPrefab;
	[SerializeField]
	private Transform _entryParent;

	private string _memberID;
	private string _leaderboardKey = "highscores";

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

			// Players get unique ids (almost certainly). 
			_memberID = Random.Range(0, int.MaxValue).ToString();
			Debug.Log($"Member ID: {_memberID}");
		});
	}

	/// <summary>
	/// Get player name from input field. 
	/// </summary>
	public void SetName(/*string playerName*/)
	{
		LootLockerSDKManager.SetPlayerName(
			_nameInputField.text/*playerName*/,
			(response) =>
			{
				if (response.success)
				{
					Debug.Log("Successfully set player name");
				}
				else
				{
					Debug.Log("Error setting player name");
				}
			});
	}

    /// <summary>
    /// Called when game is beaten. Submits score to lootlocker leaderboard. 
    /// </summary>
    public void SubmitHighScore()
    {
		LootLockerSDKManager.SubmitScore(
			Random.Range(0, int.MaxValue).ToString(),
			int.Parse(_scoreInputField.text),
			_leaderboardKey,
			_nameInputField.text,
			(response) =>
			{
				if (response.statusCode == 200)
				{
					Debug.Log("Successfully added score to leaderboard. ");
				}
				else
				{
					Debug.LogWarning($"Failed adding score to leaderboard: {response.Error}");
				}
			});
    }

	public void ShowScores()
    {
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

		entry.GetComponent<HighScoreEntry>().SetupEntry(
			leaderboardMember.rank.ToString(),
			leaderboardMember.metadata,
			leaderboardMember.score.ToString());
    }
}