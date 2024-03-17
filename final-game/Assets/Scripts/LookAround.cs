using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private float _cinemachineTargetYaw; // Kameran�n yatay rotasyonu hedefi
    private float _cinemachineTargetPitch; // Kameran�n dikey rotasyonu hedefi
    public GameObject cinemachineTarget;
    public float topClamp = 70.0f; // Kameran�n yukar� hareket edebilece�i maksimum a��
    public float bottomClamp = -30.0f; // Kameran�n a�a�� hareket edebilece�i maksimum a��
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

            // Hedef nesnenin rotasyonunu kullanarak kameran�n yatay rotasyonunu g�ncelle
            _cinemachineTargetYaw += mouseX * rotationSpeed;

            // Dikey rotasyonun s�n�rlar�n� kontrol et ve g�ncelle
            _cinemachineTargetPitch -= mouseY * rotationSpeed;
            _cinemachineTargetPitch = Mathf.Clamp(_cinemachineTargetPitch, bottomClamp, topClamp);
        }

        // Hedef nesnenin rotasyonunu g�ncelle
        cinemachineTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + cameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);

        // Kameran�n rotasyonunu g�ncelle
        CinemachineCameraTarget.transform.rotation = cinemachineTarget.transform.rotation;
    }
}
