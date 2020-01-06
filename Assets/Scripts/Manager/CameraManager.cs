using UnityEngine;
using UnityEngine.UI;

public class CameraManager: MonoBehaviour {
    [SerializeField] public MainCameraController mainCameraController;
    [SerializeField] public AimCameraController aimCameraController;
    [SerializeField] public Button aimButton;

    private bool isAiming = false;

    void Start() {
        aimButton.onClick.AddListener(onAimButtonClick);
    }

    private void onAimButtonClick() {
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