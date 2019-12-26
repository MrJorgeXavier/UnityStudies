using UnityEngine;
using UnityEngine.InputSystem;

abstract class Command<T> where T: struct {
    public virtual bool IsActive {
        get { return false; }
    }
    protected InputAction action;
    protected T input {
        get { return action.ReadValue<T>(); }
    }

    protected Command(InputAction action) {
        this.action = action;
    }

}