// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""650e9335-e82f-4355-8766-33a07214fca0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9711fa41-0c96-4b6f-ad77-1cee358bf01e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimX"",
                    ""type"": ""Value"",
                    ""id"": ""62059d19-2071-4204-8e6c-e916a2422bef"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimY"",
                    ""type"": ""Value"",
                    ""id"": ""2d8ba34c-f84f-46b3-8a8f-dcd99a3c64fd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2e46151c-fefc-4371-964c-1efcd953378d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""b285bfb9-2b1a-48ae-b1b9-b57849e545fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""6d1187aa-496e-44e0-b604-bd6384d55db3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""e10b55bf-cb10-4361-bfd9-562118bf85fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""5c4d85a5-709f-424d-84b8-acc64bc66286"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""3ebea23f-f486-4a5a-8c53-3f7a1611db6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""224f01f9-661d-4f75-9338-ee15bedd2abc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""00a7ce92-88f4-410e-a51d-f79658931eed"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d85cbb6b-211d-4b96-a30a-451b7ac4c2ce"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7e4ea4f1-52d4-47b6-b1b8-8fcd5654947b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6da4c086-3c05-4a9d-973e-5c3498152817"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ea4869a1-d1f3-485e-b80d-f5e8bfc350b0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""756c4085-5b77-4d7a-9957-82d01b03f670"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33ac4677-bab6-42b4-9da7-df9bd302ec18"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5d74b33-be8c-4fe9-a8ce-7f47f13d0a03"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d6d845f-c0bf-4fac-9a5e-aa85be9953a4"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone,Scale(factor=10)"",
                    ""groups"": ""Controller"",
                    ""action"": ""AimX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f10ab2ad-7bfa-4d54-b66b-b3c175dc1598"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa472c1-0db9-4c61-8bfc-57c98a72a630"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone,Scale(factor=10)"",
                    ""groups"": ""Controller"",
                    ""action"": ""AimY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23e5d007-3800-4446-b39c-cb327a0f9392"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4265fe0-95d8-4b01-a9a2-ce2e7d082f41"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d9fe708-a285-4050-957d-6b6aa4065cb4"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e59f757e-d953-42d4-91f3-12d8221367d0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""380a8a40-63fb-4e45-a3e6-327086593709"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6da0308-883a-448d-8ff9-80aff17efb06"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e894f1c9-c41a-4075-b2fe-17b608a57377"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6adc58a5-3053-4157-8293-abb68252a58e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""89d8b323-f492-4ab6-9989-123d94e768c0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""80321089-0879-4af1-9821-366736cc3324"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""452d0d89-672d-46b7-b602-702f7228b4f0"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3a69550-88c2-4ab6-8649-babd89314eed"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d6fe4f8-403f-4e8b-b461-d571ed1f59ad"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0239f09d-8ec3-4e7f-addd-c99e87a23999"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InMenu"",
            ""id"": ""3063fd1e-9099-4005-b305-53a8e9b9ea4e"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""1ec545ba-c3ab-4bee-84b9-1d54603ca3b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d6a06f14-1f35-4ec2-8ed1-8e789c4cc920"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feb5c5db-251e-4058-8ca5-317a44972f62"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_AimX = m_PlayerMovement.FindAction("AimX", throwIfNotFound: true);
        m_PlayerMovement_AimY = m_PlayerMovement.FindAction("AimY", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Shoot = m_PlayerMovement.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerMovement_Escape = m_PlayerMovement.FindAction("Escape", throwIfNotFound: true);
        m_PlayerMovement_SwitchWeapon = m_PlayerMovement.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_PlayerMovement_Reload = m_PlayerMovement.FindAction("Reload", throwIfNotFound: true);
        m_PlayerMovement_Melee = m_PlayerMovement.FindAction("Melee", throwIfNotFound: true);
        // InMenu
        m_InMenu = asset.FindActionMap("InMenu", throwIfNotFound: true);
        m_InMenu_Escape = m_InMenu.FindAction("Escape", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_AimX;
    private readonly InputAction m_PlayerMovement_AimY;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Shoot;
    private readonly InputAction m_PlayerMovement_Escape;
    private readonly InputAction m_PlayerMovement_SwitchWeapon;
    private readonly InputAction m_PlayerMovement_Reload;
    private readonly InputAction m_PlayerMovement_Melee;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @AimX => m_Wrapper.m_PlayerMovement_AimX;
        public InputAction @AimY => m_Wrapper.m_PlayerMovement_AimY;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Shoot => m_Wrapper.m_PlayerMovement_Shoot;
        public InputAction @Escape => m_Wrapper.m_PlayerMovement_Escape;
        public InputAction @SwitchWeapon => m_Wrapper.m_PlayerMovement_SwitchWeapon;
        public InputAction @Reload => m_Wrapper.m_PlayerMovement_Reload;
        public InputAction @Melee => m_Wrapper.m_PlayerMovement_Melee;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @AimX.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAimX;
                @AimX.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAimX;
                @AimX.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAimX;
                @AimY.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAimY;
                @AimY.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAimY;
                @AimY.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAimY;
                @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnShoot;
                @Escape.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnEscape;
                @SwitchWeapon.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSwitchWeapon;
                @Reload.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnReload;
                @Melee.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMelee;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @AimX.started += instance.OnAimX;
                @AimX.performed += instance.OnAimX;
                @AimX.canceled += instance.OnAimX;
                @AimY.started += instance.OnAimY;
                @AimY.performed += instance.OnAimY;
                @AimY.canceled += instance.OnAimY;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // InMenu
    private readonly InputActionMap m_InMenu;
    private IInMenuActions m_InMenuActionsCallbackInterface;
    private readonly InputAction m_InMenu_Escape;
    public struct InMenuActions
    {
        private @PlayerControls m_Wrapper;
        public InMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_InMenu_Escape;
        public InputActionMap Get() { return m_Wrapper.m_InMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInMenuActions instance)
        {
            if (m_Wrapper.m_InMenuActionsCallbackInterface != null)
            {
                @Escape.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_InMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public InMenuActions @InMenu => new InMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAimX(InputAction.CallbackContext context);
        void OnAimY(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
    }
    public interface IInMenuActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}
