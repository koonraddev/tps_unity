using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacesMovement : MonoBehaviour
{
    private int activeLane;
    public bool backCamera;

    public Camera mainCamera;
    private CameraMovement camMov;

    private Transform[] lanes = new Transform[5];
    public Transform lane0;
    public Transform lane1;
    public Transform lane2;
    public Transform lane3;
    public Transform lane4;

    Vector3 offsetCamera;
    public float movementSpeed;

    public float stepPlayer;
    public GameObject playerObject;
    private PlayerMovement playerMov;


    private float playerPosY;
    private float playerPosX;

    void Start()
    {
        camMov = mainCamera.GetComponent<CameraMovement>();
        playerMov = playerObject.GetComponent<PlayerMovement>();
        activeLane = 1;
        backCamera = camMov.backCamera;
        lanes[0] = lane0;
        lanes[1] = lane1;
        lanes[2] = lane2;
        lanes[3] = lane3;
        lanes[4] = lane4;
        movementSpeed = playerMov.GetMovementSpeed();
    }

    void Update()
    {
        stepPlayer = movementSpeed * Time.deltaTime;

        backCamera = camMov.backCamera;
        activeLane = playerMov.GetActiveLane();

        playerPosY = playerObject.transform.position.y;
        playerPosX = playerObject.transform.position.x;
        GetOffset();
        
    }

    public void GetOffset()
    {
        /*
        camMov.offsetX = activeLane switch
        {
            0 => -3.50f,
            1 => -1.75f,
            2 => 0f,
            3 => 1.75f,
            4 => 3.50f,
            _ => 0f,
        };
        */

        camMov.offsetX = playerPosX;
        camMov.offsetY = playerPosY;
    }
}
