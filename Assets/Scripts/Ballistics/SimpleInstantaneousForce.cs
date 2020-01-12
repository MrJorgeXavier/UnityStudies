using UnityEngine;

public class SimpleInstantaneousForce: BallisticForce {
    private Vector3 force;

    override public bool IsActive { get { return this.force != Vector3.zero; } }

    public  SimpleInstantaneousForce(Vector3 force) {
        this.force = force;
    }

    public override Vector3 GetUpdatedForce() {
        Vector3 force = this.force;
        this.force = Vector3.zero;
        return force;
    }
}