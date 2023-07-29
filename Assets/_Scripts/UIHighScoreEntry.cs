using LootLocker.Requests;
using System;
using TMPro;
using UnityEngine;

public class UIHighScoreEntry : MonoBehaviour
{
	public static event Action OnSubmitScore;

	[SerializeField]
	private GameObject _winCanvas;
	[SerializeField]
	private TMP_InputField _nameInputField;
	[SerializeField]
	private TextMeshProUGUI _winText;

    private string _leaderboardKey = "highscores";

    private void Start()
    {
//		GameManager.OnWin += SetupUI;
		Target.OnGameOver += SetupUI;
    }

    private void OnDisable()
    {
//		GameManager.OnWin -= SetupUI;
		Target.OnGameOver -= SetupUI;
	}

	private void SetupUI(int lastLevelScore)
    {
		_winCanvas.SetActive(true);
		_winText.text = $"You Win!!!\nScore: {lastLevelScore}\nTotal Score: {S.I.GM.Score}";
    }

	public void HandleSubmitButtonPress()
    {
		if (_nameInputField.text.Length == 0)
        {
			_winText.text = "Enter your name";
        }
        else
        {
			SubmitHighScore();
        }
    }

	/// <summary>
	/// Called when game is beaten. Submits score to lootlocker leaderboard. 
	/// </summary>
	public void SubmitHighScore()
	{
		string name = _nameInputField.text;

		LootLockerSDKManager.SubmitScore(
			UnityEngine.Random.Range(0, int.MaxValue).ToString(),
			S.I.GM.Score,
			_leaderboardKey,
			name,
			(response) =>
			{
				if (response.statusCode == 200)
				{
					Debug.Log("Successfully added score to leaderboard. ");

					_winCanvas.SetActive(false);
					OnSubmitScore?.Invoke();
				}
				else
				{
					Debug.LogWarning($"Failed adding score to leaderboard: {response.Error}");
				}
			});
	}
}