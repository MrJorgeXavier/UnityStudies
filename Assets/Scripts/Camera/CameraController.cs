using UnityEngine;
public class CameraController: MonoBehaviour {
    public Vector2 focusOffset = new Vector2(2, 3);
    public float focusTransitionSpeed = 10f;
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
        if(focusCommand.FocusedObject != null) performFocus(focusCommand.FocusedObject);

    }


    void OnEnable() {
        input.Camera.Enable();
    }

    void OnDisable() {
        input.Camera.Disable();
    }

    private void performFocus(Transform target) {
        float speed = focusTransitionSpeed * Time.fixedDeltaTime;
        Quaternion oldRotation = transform.rotation;
        Vector3 refVelocity = Vector3.zero;
        Vector3 offset = focusOffsetFrom(target);
        Vector3 newPosition = target.position + offset;
        Vector3 interpolatedPosition = Vector3.Lerp(transform.position, newPosition, speed);
        transform.position = interpolatedPosition;
        transform.LookAt(target);
        transform.rotation = Quaternion.Lerp(oldRotation, transform.rotation, speed);
    }

    private Vector3 focusOffsetFrom(Transform target) {
        float xDiference = Mathf.Abs(target.position.x) - Mathf.Abs(transform.position.x);
        float zDiference = Mathf.Abs(target.position.z) - Mathf.Abs(transform.position.z);
        if(xDiference > zDiference) {
            return new Vector3(0, focusOffset.y, focusOffset.x);
        } else {
            return new Vector3(focusOffset.x, focusOffset.y, 0);
        }
    }
}