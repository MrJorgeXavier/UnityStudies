using UnityEngine;
using UnityEngine.UI;

public class GunController: MonoBehaviour {
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public AimCameraController aimController;
    [SerializeField] public Button fireButton;
    public Gun gun;

    void Start() {
        fireButton.onClick.AddListener(OnFireButtonClick);
    }

    private void OnFireButtonClick() {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        FireGun(projectile.GetComponent<ProjectileController>());
    }

    private void FireGun(ProjectileController projectileController) {
        if(projectileController.Shooting) return;
        Debug.Log("FIRING!");
        projectileController.AddBallisticForce(
            gun.GetShotForce(
                aimController.AimDirection()
            )
        );
        projectileController.Shooting = true;
    }

}