using UnityEngine;

public class ShotManager: MonoBehaviour {
    [SerializeField] public GunController gunController;
    
    void Start() {
        gunController.gun = new SimpleCannon();
    }
}