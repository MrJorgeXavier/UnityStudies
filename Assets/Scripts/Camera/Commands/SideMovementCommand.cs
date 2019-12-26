using UnityEngine;
using UnityEngine.InputSystem;

class SideMovementCommand: ComposedCommand<float, Vector2> {
    public SideMovementCommand(InputAction sideMovementAction, InputAction deltaAction): base(sideMovementAction, deltaAction) {}
}