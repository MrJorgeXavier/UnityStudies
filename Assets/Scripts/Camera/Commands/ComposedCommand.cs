using UnityEngine;
using UnityEngine.InputSystem;

abstract class ComposedCommand<T, Modifier>: Command<T> 
    where T: struct
    where Modifier: struct {
    protected InputAction modifierAction;
    protected Modifier modifierInput {
        get { return modifierAction.ReadValue<Modifier>(); }
    }
    public virtual void ConfigureAction(InputAction action, InputAction modifier) {
        this.modifierAction = modifier;
        ConfigureAction(action);
    }
}