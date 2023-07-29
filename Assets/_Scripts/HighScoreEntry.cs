using TMPro;
using UnityEngine;

public class HighScoreEntry : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _rankText;
	[SerializeField]
	private TextMeshProUGUI _nameText;
	[SerializeField]
	private TextMeshProUGUI _scoreText;

	public void SetupEntry(string rank, string name, string score)
    {
		_rankText.text = rank;
		_nameText.text = name;
		_scoreText.text = score;
    }
}