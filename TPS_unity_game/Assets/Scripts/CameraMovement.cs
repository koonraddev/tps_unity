using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera mainCamera;
    public bool backCamera;

    public Transform FrontCameraPlace;
    public Transform BackCameraPlace;

    public Vector3 BackCameraStartPlace;
    public float speed;
    public float multiplier;

    [Header("Floating Effect")]
    public float lineScaleX;
    public float lineScaleY;
    public float frequency;

    [Header("FOV Settings")]
    public float Shifting;
    public float NOShifting;
    [Space(10)]
    public float ShiftingFrontCam;
    public float NOShiftingFrontCam;
    [Space(10)]

    public bool runON;
    Vector3 BackCameraPosition;
    Vector3 FrontCameraPosition;
    public float offsetX;
    public float offsetY;
    public float backFrontMultiplier;
    public float activeLaneMultiplier;

    public int cameraMode; //0 = standard/top run  |  1 = bottom run
    void Start()
    {
        backCamera = true;
        runON = false;
        offsetX = 0;
        offsetY = 0;
        multiplier = backFrontMultiplier;
        cameraMode = 1;
        BackCameraStartPlace = BackCameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
        BackCameraPosition = BackCameraStartPlace;
        FrontCameraPosition = FrontCameraPlace.position;
        if (cameraMode == 1)
        {
            BackCameraPosition.x += offsetX;
            FrontCameraPosition.x += offsetX;
            
            FrontCameraPosition.y += offsetY;
            BackCameraPosition.y += offsetY;
        }

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
                    //mainCamera.transform.position = new Vector3(BackCameraPosition.x + x, BackCameraPosition.y + y, BackCameraPosition.z);
                    //mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, BackCameraPosition, step * multiplier);
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(BackCameraPosition.x + x, BackCameraPosition.y + y, BackCameraPosition.z), step * multiplier);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, BackCameraPlace.rotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, Shifting, speed * Time.deltaTime);
                }
                else
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, BackCameraPosition, step * multiplier);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, BackCameraPlace.rotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, NOShifting, speed * Time.deltaTime);
                }

            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(FrontCameraPosition.x + x, FrontCameraPosition.y + y, FrontCameraPosition.z), step * multiplier);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, FrontCameraPlace.localRotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, ShiftingFrontCam, speed * Time.deltaTime);
                }
                else
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, FrontCameraPosition, step * multiplier);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, FrontCameraPlace.localRotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, NOShifting, speed * Time.deltaTime);
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
