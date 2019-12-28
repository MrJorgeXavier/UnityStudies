using UnityEngine;
using UnityEngine.InputSystem;

class LookCommand: ComposedCommand<float, Vector2> {
    public override bool Activated {
        get {return input != 0 && modifierInput != Vector2.zero;}
    }
    
    public LookCommand(InputAction lookAction, InputAction deltaAction): base(lookAction, deltaAction) {}
}