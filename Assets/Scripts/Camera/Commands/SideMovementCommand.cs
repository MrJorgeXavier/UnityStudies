using UnityEngine;
using UnityEngine.InputSystem;

class SideMovementCommand: ComposedCommand<float, Vector2> {
    public override bool IsActive {
        get {return input != 0 && modifierInput != Vector2.zero;}
    }
    
    public SideMovementCommand(InputAction sideMovementAction, InputAction deltaAction): base(sideMovementAction, deltaAction) {}
}