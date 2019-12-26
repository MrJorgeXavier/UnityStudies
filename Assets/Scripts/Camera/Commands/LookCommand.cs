using UnityEngine;
using UnityEngine.InputSystem;

class LookCommand: ComposedCommand<float, Vector2> {
    public LookCommand(InputAction lookAction, InputAction deltaAction): base(lookAction, deltaAction) {}
}