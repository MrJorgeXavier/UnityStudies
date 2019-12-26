using UnityEngine;
using UnityEngine.InputSystem;

class ZoomCommand: Command<float> {
    public ZoomCommand(InputAction zoomAction): base(zoomAction){}
}