using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoorsTrigger : MonoBehaviour
{
    public float speed;
    private bool moveDoors;
    public GameObject leftDoor;
    public GameObject rightDoor;


    public Transform leftDoorPlace;
    public Transform rightDoorPlace;

    void Start()
    {
        moveDoors = false;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        if (moveDoors)
        {
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorPlace.position, step * 10);
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, leftDoorPlace.localRotation, step);

            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorPlace.position, step * 10);
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation, rightDoorPlace.localRotation, step);
        }
    }
    private void OnTriggerEnter(Collider enterInfo)
    {
        PlayerMovement player = enterInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            moveDoors = true;
        }
    }
}
