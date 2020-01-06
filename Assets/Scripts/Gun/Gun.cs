using UnityEngine;

public abstract class Gun {
    public abstract BallisticForce GetShotForce(Vector3 aim);
}