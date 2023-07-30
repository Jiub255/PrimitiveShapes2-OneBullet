using UnityEngine;

public class UICrosshair : MonoBehaviour
{
	[SerializeField]
	private GameObject _crosshairCanvas;

    private void Start()
    {
        CameraAim.OnShootBullet += (_) => ToggleCrosshair(false);
        UINextLevel.OnNextLevel += () => ToggleCrosshair(true);
        UIHighScores.OnPlayAgain += () => ToggleCrosshair(true);
        Barrier.OnLeftArea += () => ToggleCrosshair(true);
    }

    private void OnDisable()
    {
        CameraAim.OnShootBullet -= (_) => ToggleCrosshair(false);
        UINextLevel.OnNextLevel -= () => ToggleCrosshair(true);
        UIHighScores.OnPlayAgain -= () => ToggleCrosshair(true);
        Barrier.OnLeftArea -= () => ToggleCrosshair(true);
    }

    private void ToggleCrosshair(bool enable)
    {
        _crosshairCanvas.SetActive(enable);
    }
}