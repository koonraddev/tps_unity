using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoorsTrigger : MonoBehaviour
{
    public float speed;
    private bool openDoors;
    public GameObject leftDoor;
    public GameObject rightDoor;


    public Transform leftDoorPlace;
    public Transform rightDoorPlace;

    public Transform leftDoorStartPos;
    public Transform rightDoorStartPos;

    void Start()
    {
        openDoors = false;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        if (openDoors)
        {
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorPlace.position, step * 10);
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, leftDoorPlace.localRotation, step);

            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorPlace.position, step * 10);
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation, rightDoorPlace.localRotation, step);
        }
        else
        {
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorStartPos.position, step * 10);
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, leftDoorStartPos.localRotation, step);

            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorStartPos.position, step * 10);
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation,rightDoorStartPos.localRotation, step);
        }
    }
    private void OnTriggerStay(Collider enterInfo)
    {
        PlayerMovement player = enterInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            openDoors = true;
        }
    }

    public void ChangeDoorsStatus()
    {
        openDoors = !openDoors;
    }

}
