using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class OrbitCommand: ComposedCommand<float, Vector2> {
    [SerializeField] public float Speed = 5f;
    public override bool Activated {
        get {return isOrbiting;}
    }
    [NonSerialized] public Vector3 OrbitingPoint = Vector3.zero;
    private bool isOrbiting = false;
    
    override public void ConfigureAction(InputAction action, InputAction modifier) {
        base.ConfigureAction(action, modifier);
        action.performed += _ => OnOrbitActionPerformed();
        action.canceled += _ => OnOrbitActionPerformed();
    }

    private void OnOrbitActionPerformed() {
        isOrbiting = input == 1;
        if(isOrbiting && OrbitingPoint == Vector3.zero) {
            OrbitingPoint = Camera.main.transform.position + (Camera.main.transform.forward.normalized * 3.5f);
        } else {
            OrbitingPoint = Vector3.zero;
        }    
    }

    public void PerformOrbit(Transform self, Vector3 target, float deltaTime) {
        float speed = Speed * 10 * deltaTime;
        self.parent.Rotate(Vector3.up, modifierInput.x * speed);
        self.Rotate(Vector3.right, modifierInput.y * -speed);
        self.parent.position = (target + -self.forward.normalized * Vector3.Distance(self.position, target));
    }
}