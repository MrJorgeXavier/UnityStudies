using UnityEngine;
public class CameraController: MonoBehaviour {
    
    private InputManager input;
    [SerializeField] FocusCommand focusCommand = new FocusCommand();
    private LookCommand lookCommand = new LookCommand();
    [SerializeField] OrbitCommand orbitCommand = new OrbitCommand();
    private SideMovementCommand sideMovementCommand = new SideMovementCommand();
    [SerializeField] ZoomCommand zoomCommand = new ZoomCommand();

    private Transform lastFocusedObject = null;

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
        // Debug.Log("isSideMoving: " + sideMovementCommand.IsActive);
        // Debug.Log("isLooking: " + lookCommand.IsActive);
        if(focusCommand.Activated) {
            lastFocusedObject = focusCommand.FocusedObject;
            focusCommand.PerformInterpolatedFocus(
                transform,
                focusCommand.FocusedObject.position,
                Time.fixedDeltaTime
            );
        } 
        else if(orbitCommand.Activated) {
            orbitCommand.PerformOrbit(
                transform,
                getOrbitingPoint(),
                Time.fixedDeltaTime
            );
        }
        else if(zoomCommand.Activated) {
            zoomCommand.PerformZoom(
                transform,
                Time.fixedDeltaTime
            );
        }
        else if(lookCommand.Activated) {
            lookCommand.PerformLook(
                transform,
                Time.fixedDeltaTime
            );
        }

    }


    void OnEnable() {
        input.Camera.Enable();
    }

    void OnDisable() {
        input.Camera.Disable();
    }

    private Vector3 getOrbitingPoint() {
        if(lastFocusedObject != null) return lastFocusedObject.position;
        else return orbitCommand.OrbitingPoint;
    }
}