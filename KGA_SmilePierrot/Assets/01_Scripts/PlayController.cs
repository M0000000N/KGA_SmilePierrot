using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 4.0f; // 마우스 회전 속도

    [SerializeField]
    private float lookSensitivity;

    //카메라 각도 제한 
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0f;
    private float currentCameraRotationY = 0f;

    [SerializeField]
    private Camera camera;

    void Update()
    {
        if (GameManager.Instance.IsPause == false)
        {
            cameraRotation();
        }
    }

    //상하 
    private void cameraRotation()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * lookSensitivity;
        currentCameraRotationX -= cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); // 각도 제한 

        float yRotation = Input.GetAxisRaw("Mouse X");
        float cameraRotationY = yRotation * lookSensitivity;
        currentCameraRotationY += cameraRotationY;
        currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -cameraRotationLimit, cameraRotationLimit);

        camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, currentCameraRotationY, 0);
    }

}