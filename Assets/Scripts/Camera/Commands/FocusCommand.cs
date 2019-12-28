using UnityEngine;
using UnityEngine.InputSystem;

class FocusCommand: ComposedCommand<int, Vector2> {
    public override bool Activated {
        get {
            return action.triggered;
        }
    }

    public Transform FocusedObject = null;

    public FocusCommand(InputAction focusAction, InputAction positionModifier): base(focusAction, positionModifier) {
        focusAction.performed += _ => OnFocusActionPerformed();
    }

    private void OnFocusActionPerformed() {
        if (
            Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(modifierInput.x, modifierInput.y, 0)), out RaycastHit hit)
            && hit.transform != null
        ) {
            FocusedObject = hit.transform;
        } else {
            FocusedObject = null;
        }
    }
}