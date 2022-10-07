using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacesMovement : MonoBehaviour
{
    private int activeLane;
    public bool backCamera;

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
        playerMov = playerObject.GetComponent<PlayerMovement>();
        activeLane = 1;
        backCamera = true;
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

        activeLane = playerMov.GetActiveLane();

        if (activeLane == 0)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x + 3.50f, transform.position.y, transform.position.z);
        }
        if (activeLane == 1)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x + 1.75f, transform.position.y, transform.position.z);
        }
        if (activeLane == 2)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x, transform.position.y, transform.position.z);
        }
        if (activeLane == 3)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x - 1.75f, transform.position.y, transform.position.z);
        }
        if (activeLane == 4)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x - 3.50f, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, offsetCamera, stepPlayer);
    }
}
