using UnityEngine;
using UnityEngine.InputSystem;

class SideMovementCommand: ComposedCommand<float, Vector2> {
    public override bool Activated {
        get {return input != 0 && modifierInput != Vector2.zero;}
    }
}