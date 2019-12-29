using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
class ZoomCommand: Command<Vector2> {

    [SerializeField] public float Speed = 20f;
    public override bool Activated {
        get {return input != Vector2.zero;}
    }

    public void PerformZoom(Transform self, float deltaTime) {
        self.parent.position += (self.forward.normalized * -Mathf.Sign(input.y) * Speed * deltaTime);
    }
}