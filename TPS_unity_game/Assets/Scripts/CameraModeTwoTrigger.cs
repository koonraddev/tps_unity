using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeTwoTrigger : MonoBehaviour
{
    public float CameraHeight;
    public float CameraDistance;

    public GameObject mainCamera;
    private CameraMovement camMov;

    public Transform BackCameraPlace;
    private Vector3 CameraMode1Position;

    public GameObject player;
    private PlayerMovement playerMov;

    public float speed;
    void Start()
    {
        camMov = mainCamera.GetComponent<CameraMovement>();
        playerMov = player.GetComponent<PlayerMovement>();
        CameraHeight = 6;
        CameraDistance = 5;
        speed = 150;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;

        if (camMov.cameraMode == 2)
        {
            CameraMode1Position.x = playerMov.GetActiveLanePosition().x;
            CameraMode1Position.y = CameraHeight;
            CameraMode1Position.z = player.transform.position.z - CameraDistance;
            BackCameraPlace.transform.position = Vector3.MoveTowards(BackCameraPlace.transform.position, CameraMode1Position, step);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            camMov.cameraMode = 2;
        }
    }
}
