using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class FocusCommand: ComposedCommand<float, Vector2> {
    [NonSerialized] public Transform FocusedObject = null;
    [SerializeField] public float Speed = 10f;
    [SerializeField] public float Offset = 5;    
    [SerializeField] public bool KeepFocus = false;

    override public bool Activated {
        get { return FocusedObject != null;}
    }

    override public void ConfigureAction(InputAction action, InputAction modifier) {
        base.ConfigureAction(action, modifier);
        action.performed += _ => OnFocusActionPerformed();
    }

    private void OnFocusActionPerformed() {
        
        if (
            Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(modifierInput.x, modifierInput.y, 0)), out RaycastHit hit)
            && hit.transform != null
        ) {
            FocusedObject = hit.transform;
        } else {
            FocusedObject = null;
        }
    }

    public void PerformInterpolatedFocus(Transform self, Transform target, float deltaTime) {
        float speed = this.Speed * deltaTime;
        
        Quaternion oldRotation = self.rotation;
        Vector3 oldPosition = self.position;

        Vector3 offset = focusOffsetFrom(self, target);
        Vector3 newPosition = target.position + offset;
        Vector3 interpolatedPosition = Vector3.Lerp(self.position, newPosition, speed);
        
        self.parent.position = interpolatedPosition;
        self.LookAt(target);
        self.rotation = Quaternion.Lerp(oldRotation, self.rotation, speed);

        if(!KeepFocus 
            && oldRotation == self.rotation 
            && oldPosition == self.position) {
            FocusedObject = null;
        }
    }

    private Vector3 focusOffsetFrom(Transform self, Transform target) {
        return (self.position - target.position).normalized * (target.localScale.magnitude / 2 + Offset);        
    }
}