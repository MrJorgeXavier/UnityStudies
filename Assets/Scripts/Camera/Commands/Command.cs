using UnityEngine;
using UnityEngine.InputSystem;

abstract class Command<T> where T: struct {
    public virtual bool Activated {
        get { return action.triggered; }
    }
    protected InputAction action;
    protected T input {
        get { return action.ReadValue<T>(); }
    }

    public virtual void ConfigureAction(InputAction action) {
        this.action = action;
    }

}