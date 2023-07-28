using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Controls C { get; private set; }

    private void Awake()
    {
        C = new Controls();

        C.Input.Enable();
    }
}