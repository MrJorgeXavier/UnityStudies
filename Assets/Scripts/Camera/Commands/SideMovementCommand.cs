using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class SideMovementCommand: ComposedCommand<float, Vector2> {
    [SerializeField] public float Speed = 5f;
    public override bool Activated {
        get {
            return isMoving && modifierInput != Vector2.zero;
        }
    }

    private bool isMoving = false;

    override public void ConfigureAction(InputAction action, InputAction modifier) {
        base.ConfigureAction(action, modifier);
        action.performed += _ => OnSideMovementActionPerformed();
        action.canceled += _ => OnSideMovementActionPerformed();
    }

    private void OnSideMovementActionPerformed() {
        isMoving = input == 1;
    }

    public void PerformSideMovement(Transform self, float deltaTime) {
        self.parent.position+=(-self.right.normalized * modifierInput.x * Speed * deltaTime);
        self.parent.position+=(-self.up.normalized * modifierInput.y * Speed * deltaTime);
    }
}