using UnityEngine;
using UnityEngine.InputSystem;

abstract class Command<T> where T: struct {
    public bool IsActive {
        get { return isActive; }
    }
    protected InputAction action;
    protected T input {
        get { return action.ReadValue<T>(); }
    }
    private bool isActive = false;

    protected Command(InputAction action) {
        this.action = action;
    }

}