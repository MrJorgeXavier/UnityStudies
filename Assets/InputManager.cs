// GENERATED AUTOMATICALLY FROM 'Assets/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""b72530e7-6f3e-44ae-b3a7-1bcfa3514ee4"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Button"",
                    ""id"": ""cd0c3197-6d88-4853-ab40-32e02f4c5777"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Focus"",
                    ""type"": ""Button"",
                    ""id"": ""efa20aa3-f6f1-4824-b0ae-3f0cfcf4563f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SideMovement"",
                    ""type"": ""Button"",
                    ""id"": ""dee4ef07-9f4b-4156-9aff-6d987977a491"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""fd3aff78-b03a-40bb-8f59-5a689d92f7c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Orbit"",
                    ""type"": ""Button"",
                    ""id"": ""99475d09-601c-4dc8-a3b7-9a8647135b1d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Button"",
                    ""id"": ""bc3acd10-0e90-4170-81b1-1a1c52369827"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Button"",
                    ""id"": ""1b5587d4-2b6d-46d3-8480-4597362cec69"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""392fb6e4-73e8-45b9-8328-0ecdfe8764b1"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d68d076-a6bd-4c98-94c6-c6f8f9dc6b24"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95cb083b-5f2a-4741-b6a4-68ab95ed5f89"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SideMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdb8d9f3-d60f-430e-b813-bd9157944c1d"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Orbit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90475818-b3cb-4970-b4b4-4f6eafb40fea"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be7d0155-d1a8-4730-b18d-0b07e4a7dc08"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""609c98c9-a4b1-4144-afb2-212cc6dfaa98"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
        m_Camera_Focus = m_Camera.FindAction("Focus", throwIfNotFound: true);
        m_Camera_SideMovement = m_Camera.FindAction("SideMovement", throwIfNotFound: true);
        m_Camera_Look = m_Camera.FindAction("Look", throwIfNotFound: true);
        m_Camera_Orbit = m_Camera.FindAction("Orbit", throwIfNotFound: true);
        m_Camera_Delta = m_Camera.FindAction("Delta", throwIfNotFound: true);
        m_Camera_Position = m_Camera.FindAction("Position", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Zoom;
    private readonly InputAction m_Camera_Focus;
    private readonly InputAction m_Camera_SideMovement;
    private readonly InputAction m_Camera_Look;
    private readonly InputAction m_Camera_Orbit;
    private readonly InputAction m_Camera_Delta;
    private readonly InputAction m_Camera_Position;
    public struct CameraActions
    {
        private @InputManager m_Wrapper;
        public CameraActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
        public InputAction @Focus => m_Wrapper.m_Camera_Focus;
        public InputAction @SideMovement => m_Wrapper.m_Camera_SideMovement;
        public InputAction @Look => m_Wrapper.m_Camera_Look;
        public InputAction @Orbit => m_Wrapper.m_Camera_Orbit;
        public InputAction @Delta => m_Wrapper.m_Camera_Delta;
        public InputAction @Position => m_Wrapper.m_Camera_Position;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Focus.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnFocus;
                @Focus.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnFocus;
                @Focus.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnFocus;
                @SideMovement.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSideMovement;
                @SideMovement.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSideMovement;
                @SideMovement.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSideMovement;
                @Look.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook;
                @Orbit.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnOrbit;
                @Orbit.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnOrbit;
                @Orbit.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnOrbit;
                @Delta.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDelta;
                @Position.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Focus.started += instance.OnFocus;
                @Focus.performed += instance.OnFocus;
                @Focus.canceled += instance.OnFocus;
                @SideMovement.started += instance.OnSideMovement;
                @SideMovement.performed += instance.OnSideMovement;
                @SideMovement.canceled += instance.OnSideMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Orbit.started += instance.OnOrbit;
                @Orbit.performed += instance.OnOrbit;
                @Orbit.canceled += instance.OnOrbit;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface ICameraActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnFocus(InputAction.CallbackContext context);
        void OnSideMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnOrbit(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
