using UnityEngine;
public class CameraController: MonoBehaviour {
    public Transform cameraTransform;
    private InputManager input;

    private FocusCommand focusCommand;
    private LookCommand lookCommand;
    private OrbitCommand orbitCommand;
    private SideMovementCommand sideMovementCommand;
    private ZoomCommand zoomCommand;

    void Awake() {
        input = new InputManager();
        focusCommand = new FocusCommand(input.Camera.Focus, input.Camera.Position);
        lookCommand = new LookCommand(input.Camera.Look, input.Camera.Delta);
        orbitCommand = new OrbitCommand(input.Camera.Orbit, input.Camera.Delta);
        sideMovementCommand = new SideMovementCommand(input.Camera.SideMovement, input.Camera.Delta);
        zoomCommand = new ZoomCommand(input.Camera.Zoom);
        input.Camera.Enable();
    }

    void FixedUpdate() {
        // Debug.Log("Orbiting: " + orbitCommand.IsActive);
        // Debug.Log("isSideMoving: " + sideMovementCommand.IsActive);
        // Debug.Log("isLooking: " + lookCommand.IsActive);
        // Debug.Log("isZooming: " + zoomCommand.IsActive);
        if(focusCommand.IsActive) performFocus();

    }


    void OnEnable() {
        input.Camera.Enable();
    }

    void OnDisable() {
        input.Camera.Disable();
    }

    void OnDrawGizmos() {
        if(input == null || cameraTransform == null) return;
        Gizmos.color = Color.blue;
        var target = focusCommand.Position - cameraTransform.position;
        Gizmos.DrawLine(cameraTransform.position, target);
        Gizmos.DrawSphere(target, 1f);
    }

    private void performFocus() {
        Debug.Log("performFocus");
        if (
            Physics.Raycast(cameraTransform.position, cameraTransform.position - focusCommand.Position, out RaycastHit hit, float.MaxValue)
        ) {
            if(hit.transform != null) {
                Debug.Log("FOCUS");
            } else {
                Debug.Log("Do NOT FOCUS!");
            }
        }
    }
}