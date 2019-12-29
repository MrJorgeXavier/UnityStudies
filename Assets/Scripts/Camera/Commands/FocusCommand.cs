using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class FocusCommand: ComposedCommand<float, Vector2> {
    [NonSerialized] public Transform FocusedObject = null;
    [SerializeField] public float Speed = 10f;
    [SerializeField] public Vector2 Offset = new Vector2(2, 3);    
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

    public void PerformInterpolatedFocus(Transform self, Vector3 target) {
        float speed = this.Speed * Time.fixedDeltaTime;
        Quaternion oldRotation = self.rotation;
        Vector3 oldPosition = self.position;
        Vector3 refVelocity = Vector3.zero;
        Vector3 offset = focusOffsetFrom(self, target);
        Vector3 newPosition = target + offset;
        Vector3 interpolatedPosition = Vector3.Lerp(self.position, newPosition, speed);
        self.position = interpolatedPosition;
        self.LookAt(target);
        self.rotation = Quaternion.Lerp(oldRotation, self.rotation, speed);
        if(!KeepFocus 
            && oldRotation == self.rotation 
            && oldPosition == self.position) {
            FocusedObject = null;
        }
    }

    private Vector3 focusOffsetFrom(Transform self, Vector3 target) {
        float xDiference = Mathf.Abs(target.x) - Mathf.Abs(self.position.x);
        float zDiference = Mathf.Abs(target.z) - Mathf.Abs(self.position.z);
        if(xDiference > zDiference) {
            return new Vector3(0, Offset.y, Offset.x);
        } else {
            return new Vector3(Offset.x, Offset.y, 0);
        }
    }
}