using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera mainCamera;
    public bool backCamera;

    public Transform FrontCameraPlace;
    public Transform BackCameraPlace;
    public float speed;
    public float multiplier;

    public float lineScaleX;
    public float lineScaleY;
    public float frequency;

    public bool runON;
    Vector3 BackCameraPosition;
    Vector3 FrontCameraPosition;
    public float offset;
    public float backFrontMultiplier;
    public float activeLaneMultiplier;
    void Start()
    {
        backCamera = true;
        runON = false;
        offset = 0;
        multiplier = backFrontMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        BackCameraPosition = BackCameraPlace.position;
        BackCameraPosition.x += offset;

        FrontCameraPosition = FrontCameraPlace.position;
        FrontCameraPosition.x += offset;

        var step = speed * Time.deltaTime;
        if (runON)
        {
            float angle = Mathf.PI;
            float scale = 2 / (3 - Mathf.Cos(2 * (angle + Time.time * frequency)));
            float x = scale * Mathf.Cos(angle + Time.time * frequency) * lineScaleX;
            float y = scale * Mathf.Sin(2 * (angle + Time.time * frequency)) / 2 * lineScaleY;
            if (backCamera)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    mainCamera.transform.position = new Vector3(BackCameraPosition.x + x, BackCameraPosition.y + y, BackCameraPosition.z);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, BackCameraPlace.rotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 70, speed * Time.deltaTime);
                }
                else
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, BackCameraPosition, step * multiplier);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, BackCameraPlace.rotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 55, speed * Time.deltaTime);
                }

            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    mainCamera.transform.position = new Vector3(FrontCameraPosition.x + x, FrontCameraPosition.y + y, FrontCameraPosition.z);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, FrontCameraPlace.localRotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, speed * Time.deltaTime);
                }
                else
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, FrontCameraPosition, step * multiplier);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, FrontCameraPlace.localRotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 55, speed * Time.deltaTime);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                backCamera = !backCamera;
                multiplier = backFrontMultiplier;
            }

        } 

    }

    public void RunChangeStatus()
    {
        runON = !runON;
    }

    public void MultiplierActiveLane()
    {
        multiplier = activeLaneMultiplier;
    }
}
