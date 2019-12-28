using UnityEngine;
public class CameraController: MonoBehaviour {
    
    private InputManager input;
    [SerializeField] FocusCommand focusCommand = new FocusCommand();
    private LookCommand lookCommand = new LookCommand();
    private OrbitCommand orbitCommand = new OrbitCommand();
    private SideMovementCommand sideMovementCommand = new SideMovementCommand();
    private ZoomCommand zoomCommand = new ZoomCommand();

    void Awake() {
        input = new InputManager();
        focusCommand.ConfigureAction(input.Camera.Focus, input.Camera.Position);
        lookCommand.ConfigureAction(input.Camera.Look, input.Camera.Delta);
        orbitCommand.ConfigureAction(input.Camera.Orbit, input.Camera.Delta);
        sideMovementCommand.ConfigureAction(input.Camera.SideMovement, input.Camera.Delta);
        zoomCommand.ConfigureAction(input.Camera.Zoom);
        input.Camera.Enable();
    }

    void FixedUpdate() {
        // Debug.Log("Orbiting: " + orbitCommand.IsActive);
        // Debug.Log("isSideMoving: " + sideMovementCommand.IsActive);
        // Debug.Log("isLooking: " + lookCommand.IsActive);
        // Debug.Log("isZooming: " + zoomCommand.IsActive);
        if(focusCommand.Activated) focusCommand.PerformInterpolatedFocus(transform, focusCommand.FocusedObject);

    }


    void OnEnable() {
        input.Camera.Enable();
    }

    void OnDisable() {
        input.Camera.Disable();
    }
}