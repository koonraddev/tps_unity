using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacesMovement : MonoBehaviour
{
    private int activeLane;
    public bool backCamera;

    private Transform[] lanes = new Transform[3];
    public Transform lane0;
    public Transform lane1;
    public Transform lane2;

    Vector3 offsetCamera;
    public float movementSpeed;

    public GameObject playerObject;
    private player_movement playerMov;
    void Start()
    {
        playerMov = playerObject.GetComponent<player_movement>();
        activeLane = 1;
        backCamera = true;
        lanes[0] = lane0;
        lanes[1] = lane1;
        lanes[2] = lane2;
    }

    void Update()
    {
        var stepPlayer = playerMov.movementSpeed * Time.deltaTime;

        activeLane = playerMov.GetActiveLane();

        if (activeLane == 0)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x + 1.75f, transform.position.y, transform.position.z);
        }
        if (activeLane == 1)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x, transform.position.y, transform.position.z);
        }
        if (activeLane == 2)
        {
            offsetCamera = new Vector3(lanes[activeLane].position.x - 1.75f, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, offsetCamera, stepPlayer);
    }
}
