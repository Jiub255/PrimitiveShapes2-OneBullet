//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/_Scripts/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""3ca07619-5f1a-425c-8505-ca27554f42fa"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""413a0237-2e2f-4b91-89f6-57abeee7a546"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5f4c7338-3eb6-4342-bfb4-8be69d23f831"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cbd12fa9-9fbb-4503-b09d-0925e35f7c14"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120d8529-6953-4af7-91b3-2e9bbd590759"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FreeMove"",
            ""id"": ""c5341793-f865-4fb0-936d-2efafbd6d2e4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""427b18ea-fa03-46cb-a458-1a30a530f406"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f0da0d3b-ce49-419e-9c96-d2d6e7d23c2d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce49645a-4331-43f6-b1e7-d20fc88e3487"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SwitchToGame"",
                    ""type"": ""PassThrough"",
                    ""id"": ""453f33e0-75a0-448e-b5f6-1361bae7a8e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1cfa0bba-f632-46da-9156-a951ba20f153"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2b0388ee-96f5-4afa-9466-a2c65a27794b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dd36c110-9ea8-4b11-8517-b37c329ee74f"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8b5374f8-19fe-41e7-9cfc-3fe8eba79f79"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""159c008f-1c1c-4753-9bc8-a0be3d80e61f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f4bb13a-79e8-474a-acae-39f079cc61ad"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchToGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""eccb7829-81cb-4c43-9523-e34a7491ff60"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""41bf1ece-89ed-4fc1-beb9-3a6c6675965a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""509b66ca-49e6-4d55-8884-8b1a58300091"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9909e8a5-ac4d-41f2-ba0e-2779c30e401e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d0254088-0381-485f-b6cd-0c1f2eef898f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""3f86b64e-3288-41ee-9c66-0603ccf40718"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""04ec93ea-1b9d-4b8c-9401-e3225e95e56f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""882a7d94-4fe7-4926-8b9c-b9d7fba2c9bb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""5f2656c1-ccd3-4bd4-86c8-8696ae2bcee7"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7c689cd4-7402-4d03-a57f-486e94582156"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchToFreeMove"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47cadcba-6e19-4881-b429-7261a804ee63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7be24bb2-4ff7-4a4d-851c-5b3515d4a971"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abb7ee6f-6a33-4a9a-b609-986c42647c4a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchToFreeMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_MousePosition = m_Input.FindAction("MousePosition", throwIfNotFound: true);
        m_Input_Quit = m_Input.FindAction("Quit", throwIfNotFound: true);
        // FreeMove
        m_FreeMove = asset.FindActionMap("FreeMove", throwIfNotFound: true);
        m_FreeMove_Move = m_FreeMove.FindAction("Move", throwIfNotFound: true);
        m_FreeMove_Zoom = m_FreeMove.FindAction("Zoom", throwIfNotFound: true);
        m_FreeMove_Rotate = m_FreeMove.FindAction("Rotate", throwIfNotFound: true);
        m_FreeMove_SwitchToGame = m_FreeMove.FindAction("SwitchToGame", throwIfNotFound: true);
        m_FreeMove_MouseDelta = m_FreeMove.FindAction("MouseDelta", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Click = m_Game.FindAction("Click", throwIfNotFound: true);
        m_Game_SwitchToFreeMove = m_Game.FindAction("SwitchToFreeMove", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_MousePosition;
    private readonly InputAction m_Input_Quit;
    public struct InputActions
    {
        private @Controls m_Wrapper;
        public InputActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Input_MousePosition;
        public InputAction @Quit => m_Wrapper.m_Input_Quit;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMousePosition;
                @Quit.started -= m_Wrapper.m_InputActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public InputActions @Input => new InputActions(this);

    // FreeMove
    private readonly InputActionMap m_FreeMove;
    private IFreeMoveActions m_FreeMoveActionsCallbackInterface;
    private readonly InputAction m_FreeMove_Move;
    private readonly InputAction m_FreeMove_Zoom;
    private readonly InputAction m_FreeMove_Rotate;
    private readonly InputAction m_FreeMove_SwitchToGame;
    private readonly InputAction m_FreeMove_MouseDelta;
    public struct FreeMoveActions
    {
        private @Controls m_Wrapper;
        public FreeMoveActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_FreeMove_Move;
        public InputAction @Zoom => m_Wrapper.m_FreeMove_Zoom;
        public InputAction @Rotate => m_Wrapper.m_FreeMove_Rotate;
        public InputAction @SwitchToGame => m_Wrapper.m_FreeMove_SwitchToGame;
        public InputAction @MouseDelta => m_Wrapper.m_FreeMove_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_FreeMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeMoveActions set) { return set.Get(); }
        public void SetCallbacks(IFreeMoveActions instance)
        {
            if (m_Wrapper.m_FreeMoveActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnMove;
                @Zoom.started -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnZoom;
                @Rotate.started -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnRotate;
                @SwitchToGame.started -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnSwitchToGame;
                @SwitchToGame.performed -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnSwitchToGame;
                @SwitchToGame.canceled -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnSwitchToGame;
                @MouseDelta.started -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_FreeMoveActionsCallbackInterface.OnMouseDelta;
            }
            m_Wrapper.m_FreeMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @SwitchToGame.started += instance.OnSwitchToGame;
                @SwitchToGame.performed += instance.OnSwitchToGame;
                @SwitchToGame.canceled += instance.OnSwitchToGame;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }
        }
    }
    public FreeMoveActions @FreeMove => new FreeMoveActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Click;
    private readonly InputAction m_Game_SwitchToFreeMove;
    public struct GameActions
    {
        private @Controls m_Wrapper;
        public GameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Game_Click;
        public InputAction @SwitchToFreeMove => m_Wrapper.m_Game_SwitchToFreeMove;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_GameActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnClick;
                @SwitchToFreeMove.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchToFreeMove;
                @SwitchToFreeMove.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchToFreeMove;
                @SwitchToFreeMove.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchToFreeMove;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @SwitchToFreeMove.started += instance.OnSwitchToFreeMove;
                @SwitchToFreeMove.performed += instance.OnSwitchToFreeMove;
                @SwitchToFreeMove.canceled += instance.OnSwitchToFreeMove;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IInputActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
    public interface IFreeMoveActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnSwitchToGame(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnSwitchToFreeMove(InputAction.CallbackContext context);
    }
}
