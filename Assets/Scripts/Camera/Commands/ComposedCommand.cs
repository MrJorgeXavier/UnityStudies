using UnityEngine;
using UnityEngine.InputSystem;

abstract class ComposedCommand<T, Modifier>: Command<T> 
    where T: struct
    where Modifier: struct {
    protected InputAction modifier;
    protected Modifier modifierInput {
        get { return action.ReadValue<Modifier>(); }
    }
    protected ComposedCommand(InputAction action, InputAction modifier): base(action) {
        this.modifier = modifier;
    }
}