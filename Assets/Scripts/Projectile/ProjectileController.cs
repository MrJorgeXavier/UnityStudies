using UnityEngine;
using System.Collections.Generic;

public class ProjectileController: MonoBehaviour {
    public Rigidbody projectile;

    private List<BallisticForce> ballisticForces = new List<BallisticForce>();
    
    public void AddBallisticForce(BallisticForce force) {
        force.SetProjectileController(this);
        ballisticForces.Add(force);
    }

    void Update() {
        Vector3 force = Vector3.zero;
        foreach(BallisticForce ballisticForce in ballisticForces) {
            force+=ballisticForce.GetUpdatedForce();
        }
        projectile.AddForce(force);
    }

    void OnCollisionEnter(Collision collision) {
        foreach(BallisticForce ballisticForce in ballisticForces) {
            ballisticForce.OnCollisionEnter(collision);
        }
    }

    void OnCollisionExit(Collision collision) {
        foreach(BallisticForce ballisticForce in ballisticForces) {
            ballisticForce.OnCollisionExit(collision);
        }
    }

    void OnCollisionStay(Collision collision) {
        foreach(BallisticForce ballisticForce in ballisticForces) {
            ballisticForce.OnCollisionStay(collision);
        }
    }
}