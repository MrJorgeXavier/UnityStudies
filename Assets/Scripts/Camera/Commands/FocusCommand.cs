using UnityEngine;
using UnityEngine.InputSystem;

class FocusCommand: Command<int> {
    public FocusCommand(InputAction focusAction): base(focusAction) {}
}