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

        if (activeLane == 0)
        {
            camMov.offset = -3.50f;
        }
        if (activeLane == 1)
        {
            camMov.offset = -1.75f;
        }
        if (activeLane == 2)
        {
            camMov.offset = 0f;
        }
        if (activeLane == 3)
        {
           camMov.offset = 1.75f;
        }
        if (activeLane == 4)
        {
            camMov.offset = 3.50f;
        }
    }
}
