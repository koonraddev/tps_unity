using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOnTrigger : MonoBehaviour
{
    public GameObject mainCamera;
    private CameraMovement camMov;
    private CameraStartMenu camStartMov;
   
    void Start()
    {
        camMov = mainCamera.GetComponent<CameraMovement>();
        camStartMov = mainCamera.GetComponent<CameraStartMenu>();
    }

    private void OnTriggerEnter(Collider enterInfo)
    {
        PlayerMovement player = enterInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            camMov.RunChangeStatus();
            camStartMov.RunChangeStatus();
        }
    }
}
