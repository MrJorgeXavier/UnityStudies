using UnityEngine;

public class AimCameraController: MonoBehaviour {
    private InputManager input;
    [SerializeField] LookCommand lookCommand = new LookCommand();

    void Awake() {
        input = new InputManager();
        lookCommand.ConfigureAction(input.Camera.Look, input.Camera.Delta);
    }

    void Update() {
        lookCommand.PerformLook(
            transform,
            Time.deltaTime
        );
    }

    void OnEnable() {
        Debug.Log("ENABLED!");
        Cursor.lockState = CursorLockMode.Locked;
        input.Camera.Enable();
    }

    void OnDisable() {
        Debug.Log("DISABLED!");
        Cursor.lockState = CursorLockMode.None;
        input.Camera.Disable();
    }

}