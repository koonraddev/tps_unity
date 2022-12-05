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

    public GameObject uiManagerObject;
    private UIManager uiManager;

    public GameObject distanceCounter;

    private int objectNumber;
    void Start()
    {
        camMov = mainCamera.GetComponent<CameraMovement>();
        camStartMov = mainCamera.GetComponent<CameraStartMenu>();
        playerMov = player.GetComponent<PlayerMovement>();
        uiManager = uiManagerObject.GetComponent<UIManager>();
        objectNumber = PlayerPrefs.GetInt("numberObject");
    }

    private void OnTriggerEnter(Collider enterInfo)
    {
        PlayerMovement player = enterInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            camMov.RunChangeStatus();
            camStartMov.RunChangeStatus();
            playerMov.RunChangeStatus();
            uiManager.RunChangeStatus();
            distanceCounter.SetActive(true);
            objectNumber += 1;
            PlayerPrefs.SetInt("numberObject", objectNumber);
        }
    }
}
