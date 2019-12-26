using UnityEngine;
using UnityEngine.InputSystem;

class FocusCommand: ComposedCommand<int, Vector2> {
    public override bool IsActive {
        get {
            return action.triggered;
        }
    }

    public Vector3 Position {
        get {
            var input = modifierInput;
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(input.x, input.y, -1));
            Debug.Log("Mouse position: " + pos);
            return pos;
        }
    }

    public FocusCommand(InputAction focusAction, InputAction positionModifier): base(focusAction, positionModifier) {}
}