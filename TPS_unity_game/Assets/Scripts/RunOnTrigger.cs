using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOnTrigger : MonoBehaviour
{
    public GameObject mainCamera;
    private CameraMovement camMov;
    private CameraStartMenu camStartMov;

    public GameObject player;
    private PlayerMovement playerMov;

    void Start()
    {
        camMov = mainCamera.GetComponent<CameraMovement>();
        camStartMov = mainCamera.GetComponent<CameraStartMenu>();
        playerMov = player.GetComponent<PlayerMovement>();
       
    }

    private void OnTriggerEnter(Collider enterInfo)
    {
        PlayerMovement player = enterInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            camMov.RunChangeStatus();
            camStartMov.RunChangeStatus();
            playerMov.RunChangeStatus();

        }
    }
}
