using UnityEngine;
using UnityEngine.UI;
using System;

public class GameplayManager: MonoBehaviour {
    [SerializeField] public ProjectileController projectileController;
    [SerializeField] public MainCameraController mainCameraController;
    [SerializeField] public AimCameraController aimCameraController;

    [SerializeField] public Button aimButton;

    private bool isAiming = false;

    void Start() {
        aimButton.onClick.AddListener(onAimButtonClick);
    }

    void onAimButtonClick() {
        isAiming = !isAiming;
        if(isAiming) EnableAimMode();
        else EnableFreeVisionMode();
    }

    public void EnableAimMode() {
        mainCameraController.gameObject.SetActive(false);
        aimCameraController.gameObject.SetActive(true);
    }

    public void EnableFreeVisionMode() {
        mainCameraController.gameObject.SetActive(true);
        aimCameraController.gameObject.SetActive(false);
    }
}