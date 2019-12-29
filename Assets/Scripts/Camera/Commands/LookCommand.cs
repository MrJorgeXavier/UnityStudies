using UnityEngine;
using UnityEngine.InputSystem;

class LookCommand: ComposedCommand<float, Vector2> {
    [SerializeField] public float Speed = 50f;

    private float xAxisClamp = 0f;

    public override bool Activated {
        get {return isLooking;}
    }
    bool isLooking = false;

    override public void ConfigureAction(InputAction action, InputAction modifier) {
        base.ConfigureAction(action, modifier);
        action.performed += _ => OnLookActionPerformed();
        action.canceled += _ => OnLookActionPerformed();
    }

    private void OnLookActionPerformed() {
        isLooking = input == 1;
        if(isLooking) Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
    }

    public void PerformLook(Transform self, float deltaTime) {
        float mouseX = modifierInput.x * Speed * deltaTime;
        float mouseY = modifierInput.y * Speed * deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(self, 270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(self, 90.0f);
        }

        self.Rotate(Vector3.left * mouseY);
        self.parent.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(Transform self, float value) {
        Vector3 eulerRotation = self.eulerAngles;
        eulerRotation.x = value;
        self.eulerAngles = eulerRotation;
    }
}