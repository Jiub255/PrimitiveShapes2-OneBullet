using System;
using TMPro;
using UnityEngine;

public class UINextLevel : MonoBehaviour
{
    /// <summary>
    /// GameManager listens, goes to next level. <br/>
    /// Camera listens, resets. <br/>
    /// Bullet listens, goes back to origin. 
    /// </summary>
    public static event Action OnNextLevel;

    [SerializeField]
    private GameObject _nextLevelCanvas;
	[SerializeField]
	private TextMeshProUGUI _nextLevelText;
	[SerializeField]
	private TextMeshProUGUI _nextLevelButtonText;

    private void Start()
    {
        GameManager.OnNextLevel += SetupUI;
//        Target.OnLevelOver += SetupUI;
    }

    private void OnDisable()
    {
//        Target.OnLevelOver -= SetupUI;
    }

    private void SetupUI()
    {
        Debug.Log("SetupUI");
        _nextLevelCanvas.SetActive(true);
        _nextLevelText.fontSize = 180f;
		_nextLevelText.text = $"You Beat Level\n{S.I.GM.Score}!!!";
        _nextLevelButtonText.text = $"Start Level {S.I.GM.NextLevelIndex + 1}";
    }

    /// <summary>
    /// Called by next level button. 
    /// </summary>
    public void NextLevel()
    {
        OnNextLevel?.Invoke();
        _nextLevelCanvas.SetActive(false);
    }
}