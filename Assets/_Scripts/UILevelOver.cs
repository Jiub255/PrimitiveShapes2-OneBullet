using System;
using TMPro;
using UnityEngine;

public class UILevelOver : MonoBehaviour
{
    /// <summary>
    /// GameManager listens, goes to next level. <br/>
    /// Camera listens, resets. <br/>
    /// Bullet listens, goes back to origin. 
    /// </summary>
    public static event Action OnNextLevel;

    [SerializeField]
    private GameObject _levelOverCanvas;
	[SerializeField]
	private TextMeshProUGUI _levelOverText;
	[SerializeField]
	private TextMeshProUGUI _levelOverText2;

    private void Start()
    {
        Target.OnLevelOver += SetupUI;
    }

    private void OnDisable()
    {
        Target.OnLevelOver -= SetupUI;
    }

    private void SetupUI(int levelScore)
    {
        _levelOverCanvas.SetActive(true);
		_levelOverText.text = $"You Win!!!\nScore: {levelScore}\nTotal: {S.I.GM.Score}";
		_levelOverText2.text = $"You Win!!!\nScore: {levelScore}\nTotal: {S.I.GM.Score}";
    }

    /// <summary>
    /// Called by next level button. 
    /// </summary>
    public void NextLevel()
    {
        Time.timeScale = 1f;
        OnNextLevel?.Invoke();
        _levelOverCanvas.SetActive(false);
    }
}