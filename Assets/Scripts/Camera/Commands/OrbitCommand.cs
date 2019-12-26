using UnityEngine;
using UnityEngine.InputSystem;

class OrbitCommand: ComposedCommand<float, Vector2> {
    public OrbitCommand(InputAction orbitAction, InputAction deltaAction): base(orbitAction, deltaAction){}
}