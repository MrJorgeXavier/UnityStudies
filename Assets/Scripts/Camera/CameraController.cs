using UnityEngine;
public class CameraController: MonoBehaviour {
    public Transform cameraTransform;
    public int focusTouches = 2;
    private InputManager input;

    private FocusCommand focusCommand;
    private LookCommand lookCommand;
    private OrbitCommand orbitCommand;
    private SideMovementCommand sideMovementCommand;
    private ZoomCommand zoomCommand;

    void Awake() {
        input = new InputManager();
        focusCommand = new FocusCommand(input.Camera.Focus);
        lookCommand = new LookCommand(input.Camera.Look, input.Camera.Move);
        orbitCommand = new OrbitCommand(input.Camera.Orbit, input.Camera.Move);
        sideMovementCommand = new SideMovementCommand(input.Camera.SideMovement, input.Camera.Move);
        zoomCommand = new ZoomCommand(input.Camera.Zoom);
    }

    void Update() {
        Debug.Log("Orbiting: " + orbitCommand.IsActive);
        Debug.Log("isSideMoving: " + sideMovementCommand.IsActive);
        Debug.Log("isLooking: " + lookCommand.IsActive);
        Debug.Log("isZooming: " + zoomCommand.IsActive);
        Debug.Log("isFocusing: " + focusCommand.IsActive);
    }


    void OnEnable() {
        input.Camera.Enable();
    }

    void OnDisable() {
        input.Camera.Disable();
    }
}