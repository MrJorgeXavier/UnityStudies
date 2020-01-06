using UnityEngine;
using System;

[Serializable]
public class SimpleCannon: Gun {
    [SerializeField] public float shotForce = 100f;
    public override BallisticForce GetShotForce(Vector3 aim) {
        return new SimpleInstantaneousForce(aim * shotForce);
    }

}