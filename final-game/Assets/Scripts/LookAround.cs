using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private float _cinemachineTargetYaw; // Kameranýn yatay rotasyonu hedefi
    private float _cinemachineTargetPitch; // Kameranýn dikey rotasyonu hedefi
    public GameObject cinemachineTarget;
    public float topClamp = 70.0f; // Kameranýn yukarý hareket edebileceði maksimum açý
    public float bottomClamp = -30.0f; // Kameranýn aþaðý hareket edebileceði maksimum açý
    public float cameraAngleOverride = 0.0f;
    public float rotationSpeed = 5.0f;
    public GameObject CinemachineCameraTarget; // Cinemachine kamera hedef nesnesi
    public bool LockCameraPosition = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 && !LockCameraPosition)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Hedef nesnenin rotasyonunu kullanarak kameranýn yatay rotasyonunu güncelle
            _cinemachineTargetYaw += mouseX * rotationSpeed;

            // Dikey rotasyonun sýnýrlarýný kontrol et ve güncelle
            _cinemachineTargetPitch -= mouseY * rotationSpeed;
            _cinemachineTargetPitch = Mathf.Clamp(_cinemachineTargetPitch, bottomClamp, topClamp);
        }

        // Hedef nesnenin rotasyonunu güncelle
        cinemachineTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + cameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);

        // Kameranýn rotasyonunu güncelle
        CinemachineCameraTarget.transform.rotation = cinemachineTarget.transform.rotation;
    }
}
