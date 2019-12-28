using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class FocusCommand: ComposedCommand<int, Vector2> {
    public Transform FocusedObject = null;
    [SerializeField] public float TransitionSpeed = 10f;
    [SerializeField] public Vector2 Offset = new Vector2(2, 3);
       

    override public bool Activated {
        get { return FocusedObject != null;}
    }

    override public void ConfigureAction(InputAction action, InputAction modifier) {
        base.ConfigureAction(action, modifier);
        action.performed += _ => OnFocusActionPerformed();
        Debug.Log("Configured!");
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

    public void PerformInterpolatedFocus(Transform self, Transform target) {
        float speed = TransitionSpeed * Time.fixedDeltaTime;
        Quaternion oldRotation = self.rotation;
        Vector3 refVelocity = Vector3.zero;
        Vector3 offset = focusOffsetFrom(self, target);
        Vector3 newPosition = target.position + offset;
        Vector3 interpolatedPosition = Vector3.Lerp(self.position, newPosition, speed);
        self.position = interpolatedPosition;
        self.LookAt(target);
        self.rotation = Quaternion.Lerp(oldRotation, self.rotation, speed);
    }

    private Vector3 focusOffsetFrom(Transform self, Transform target) {
        float xDiference = Mathf.Abs(target.position.x) - Mathf.Abs(self.position.x);
        float zDiference = Mathf.Abs(target.position.z) - Mathf.Abs(self.position.z);
        if(xDiference > zDiference) {
            return new Vector3(0, Offset.y, Offset.x);
        } else {
            return new Vector3(Offset.x, Offset.y, 0);
        }
    }
}