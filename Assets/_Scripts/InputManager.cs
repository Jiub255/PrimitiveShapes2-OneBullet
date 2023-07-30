using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCameraGO;
    [SerializeField]
    private GameObject _freeMoveCameraGO;
    [SerializeField]
    private SkyboxCamera _skyboxCamera;
    private Camera _mainCamera;
    private Camera _freeMoveCamera;

    public Controls C { get; private set; }

    private void Awake()
    {
        C = new Controls();
        _mainCamera = _mainCameraGO.GetComponent<Camera>();
        _freeMoveCamera = _freeMoveCameraGO.GetComponentInChildren<Camera>();

        SwitchToGame();
    }

    // Disabling for now, can't get camera rotation to work. 
/*    private void Start()
    {
        C.Game.SwitchToFreeMove.started += (_) => SwitchToFreeMove();
        C.FreeMove.SwitchToGame.started += (_) => SwitchToGame();
    }

    private void OnDisable()
    {
        C.Game.SwitchToFreeMove.started -= (_) => SwitchToFreeMove();
        C.FreeMove.SwitchToGame.started -= (_) => SwitchToGame();
    }*/

    public void SwitchToFreeMove()
    {
        _mainCamera.enabled = false;
        _mainCameraGO.SetActive(false);
        _freeMoveCameraGO.SetActive(true);
        _freeMoveCamera.enabled = true;
        _skyboxCamera.MainCameraTransform = _freeMoveCameraGO.transform.GetChild(1);

        C.Disable();

        C.Input.Enable();
        C.FreeMove.Enable();
    }

    public void SwitchToGame()
    {
        _freeMoveCamera.enabled = false;
        _freeMoveCameraGO.SetActive(false);
        _mainCameraGO.SetActive(true);
        _mainCamera.enabled = true;
        _skyboxCamera.MainCameraTransform = _mainCameraGO.transform;

        C.Disable();

        C.Input.Enable();
        C.Game.Enable();
    }
}