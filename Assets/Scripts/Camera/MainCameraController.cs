using UnityEngine;
using UnityEngine.EventSystems;

public class MainCameraController: MonoBehaviour {
    
    private InputManager input;
    [SerializeField] public EventSystem eventSystem;
    [SerializeField] FocusCommand focusCommand = new FocusCommand();
    [SerializeField] LookCommand lookCommand = new LookCommand();
    [SerializeField] OrbitCommand orbitCommand = new OrbitCommand();
    [SerializeField] SideMovementCommand sideMovementCommand = new SideMovementCommand();
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
        if(eventSystem.currentSelectedGameObject != null) return;
        if(focusCommand.Activated) {
            lastFocusedObject = focusCommand.FocusedObject;
            focusCommand.PerformInterpolatedFocus(
                transform,
                focusCommand.FocusedObject,
                Time.fixedDeltaTime
            );
            return;
        } 
        else if(orbitCommand.Activated) {
            orbitCommand.PerformOrbit(
                transform,
                getOrbitingPoint(),
                Time.fixedDeltaTime
            );
            return;
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
        else if(sideMovementCommand.Activated) {
            sideMovementCommand.PerformSideMovement(
                transform,
                Time.fixedDeltaTime
            );
        } else {
            return;
        }

        lastFocusedObject = null; //Loses focus if necessarily do anything other than Orbit or Focus an object.
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