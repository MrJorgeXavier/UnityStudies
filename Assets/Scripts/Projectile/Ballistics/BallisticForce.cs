using System;
using UnityEngine;

public abstract class BallisticForce {
    private WeakReference projectileController;

    protected ProjectileController projectile {
        get {
            if(projectileController != null && projectileController.Target is ProjectileController) {
                return projectileController.Target as ProjectileController;
            } else {
                return null;
            }
        }
    }

    public virtual void SetProjectileController(ProjectileController projectileController) {
        this.projectileController = new WeakReference(projectileController);
    }

    public abstract Vector3 GetUpdatedForce();
    public virtual void OnCollisionEnter(Collision collision){}
    public virtual void OnCollisionStay(Collision collision){}
    public virtual void OnCollisionExit(Collision collision){}
}