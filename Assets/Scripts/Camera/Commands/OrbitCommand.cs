using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class OrbitCommand: ComposedCommand<float, Vector2> {
    [SerializeField] public float Speed = 5f;
    public override bool Activated {
        get {
            return OrbitingPoint != Vector3.zero;
        }
    }

    public Vector3 OrbitingPoint = Vector3.zero;

    override public void ConfigureAction(InputAction action, InputAction modifier) {
        base.ConfigureAction(action, modifier);
        action.performed += _ => OnOrbitActionPerformed();
        action.canceled += _ => OnOrbitActionPerformed();
    }

    private void OnOrbitActionPerformed() {
        if(input == 1 && OrbitingPoint == Vector3.zero) {
            OrbitingPoint = Camera.main.transform.position + (Camera.main.transform.forward.normalized * 3.5f);
        } else {
            OrbitingPoint = Vector3.zero;
        }
        
        if(Activated) Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
    }

    public void PerformOrbit(Transform self, Vector3 target) {
        float speed = Speed * 10 * Time.fixedDeltaTime;
        self.RotateAround(target, self.up, modifierInput.x * speed);
        self.RotateAround(target, self.right, modifierInput.y * -speed);
    }
}