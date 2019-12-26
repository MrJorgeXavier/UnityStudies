using UnityEngine;
using UnityEngine.InputSystem;

class OrbitCommand: ComposedCommand<float, Vector2> {
    public override bool IsActive {
        get {return input != 0 && modifierInput != Vector2.zero;}
    }
    public OrbitCommand(InputAction orbitAction, InputAction deltaAction): base(orbitAction, deltaAction){}
}