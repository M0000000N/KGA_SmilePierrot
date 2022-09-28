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
    [SerializeField] float cameraLeftRotationLimit;
    [SerializeField] float cameraRightRotationLimit;
    [SerializeField] float cameraUpRotationLimit;
    [SerializeField] float cameraDownRotationLimit;
    private float currentCameraRotationX = 0f;
    private float currentCameraRotationY = 0f;

    [SerializeField]
    private Camera camera;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        currentCameraRotationX = 0f;
        currentCameraRotationY = 0f;
    }

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

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraUpRotationLimit, cameraDownRotationLimit); // 각도 제한 

        float yRotation = Input.GetAxisRaw("Mouse X");
        float cameraRotationY = yRotation * lookSensitivity;
        currentCameraRotationY += cameraRotationY;
        currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -cameraLeftRotationLimit, cameraRightRotationLimit);

        camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, currentCameraRotationY, 0);
    }

}