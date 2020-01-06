using UnityEngine;
using UnityEngine.UI;

public class GunController: MonoBehaviour {
    [SerializeField] public ProjectileController projectileController;
    [SerializeField] public AimCameraController aimController;
    [SerializeField] public Button fireButton;
    public Gun gun;

    void Start() {
        fireButton.onClick.AddListener(OnFireButtonClick);
    }

    private void OnFireButtonClick() {
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