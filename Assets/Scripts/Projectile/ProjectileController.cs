using UnityEngine;
using System.Collections.Generic;

public class ProjectileController: MonoBehaviour {
    public Rigidbody projectile;
    private List<BallisticForce> ballisticForces = new List<BallisticForce>();

    public bool Shooting = false;
    
    public void AddBallisticForce(BallisticForce force) {
        force.SetProjectileController(this);
        ballisticForces.Add(force);
    }

    void Update() {
        if(Shooting) {
            PerformShoot();
            UpdateShootingState();
        }
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

    private void PerformShoot() {
        Vector3 force = Vector3.zero;
        foreach(BallisticForce ballisticForce in ballisticForces) {
            force+=ballisticForce.GetUpdatedForce();
        }
        Debug.Log("ADDING FORCE: " + force);
        projectile.AddForce(force);
    }

    private void UpdateShootingState() {
        ballisticForces.RemoveAll(ShouldRemoveForce);
        if(ballisticForces.Count == 0) Shooting = false;
    }

    private bool ShouldRemoveForce(BallisticForce force) {
        return !force.IsActive;
    }
}