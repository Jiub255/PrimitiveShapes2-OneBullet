using LootLocker.Requests;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHighScoreEntry : MonoBehaviour
{
	/// <summary>
	/// UIHighScores listens, calls SetupUI. 
	/// </summary>
	public static event Action OnSubmitScore;

	[SerializeField]
	private GameObject _winCanvas;
	[SerializeField]
	private TMP_InputField _nameInputField;
	[SerializeField]
	private TextMeshProUGUI _winText;
	[SerializeField]
	private Button _submitButton;

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
		_submitButton.enabled = false;

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

					_submitButton.enabled = true;
					_winCanvas.SetActive(false);
					OnSubmitScore?.Invoke();
				}
				else
				{
					Debug.LogWarning($"Failed adding score to leaderboard: {response.Error}");

					_submitButton.enabled = true;
				}
			});
	}
}