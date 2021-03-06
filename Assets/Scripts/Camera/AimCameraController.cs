using UnityEngine;
using UnityEngine.EventSystems;

public class AimCameraController: MonoBehaviour {
    private InputManager input;
    [SerializeField] public EventSystem eventSystem;
    [SerializeField] LookCommand lookCommand = new LookCommand();

    public Vector3 AimDirection() {
        return transform.forward;
    }

    void Awake() {
        input = new InputManager();
        lookCommand.ConfigureAction(input.Camera.Look, input.Camera.Delta);
    }

    void Update() {
        if(eventSystem.currentSelectedGameObject != null) return;
        if(lookCommand.Activated) {
            lookCommand.PerformLook(
                transform,
                Time.deltaTime
            );
        }
    }

    void OnEnable() {
        Debug.Log("ENABLED!");
        Cursor.lockState = CursorLockMode.Confined;
        input.Camera.Enable();
    }

    void OnDisable() {
        Debug.Log("DISABLED!");
        Cursor.lockState = CursorLockMode.None;
        input.Camera.Disable();
    }

}