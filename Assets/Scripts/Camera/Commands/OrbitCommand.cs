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

    [NonSerialized] public Vector3 OrbitingPoint = Vector3.zero;

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
    }

    public void PerformOrbit(Transform self, Vector3 target, float deltaTime) {
        float speed = Speed * 10 * deltaTime;
        self.parent.RotateAround(target, Vector3.up, modifierInput.x * speed);
        self.parent.RotateAround(target, Vector3.right, modifierInput.y * speed);
        self.LookAt(target);
    }
}