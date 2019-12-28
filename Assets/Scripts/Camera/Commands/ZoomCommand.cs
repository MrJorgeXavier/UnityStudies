using UnityEngine;
using UnityEngine.InputSystem;

class ZoomCommand: Command<Vector2> {
    public override bool Activated {
        get {return input != Vector2.zero;}
    }
}