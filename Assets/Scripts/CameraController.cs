using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cameras")]
    public Camera firstPersonCamera;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled = false;
        mainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           toggleCamera();
        }
    }

    public void toggleCamera()
    {
        firstPersonCamera.enabled = !firstPersonCamera.enabled;
        mainCamera.enabled = !mainCamera.enabled;
    }
}
