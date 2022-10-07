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

    public float lineScaleX;
    public float lineScaleY;
    public float frequency;

    public bool runON;
    
    void Start()
    {
        backCamera = true;
        runON = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                    mainCamera.transform.position = new Vector3(BackCameraPlace.position.x + x, BackCameraPlace.position.y + y, BackCameraPlace.position.z);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, BackCameraPlace.rotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 70, speed * Time.deltaTime);
                }
                else
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, BackCameraPlace.position, step * 18);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, BackCameraPlace.rotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 55, speed * Time.deltaTime);
                }

            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    mainCamera.transform.position = new Vector3(FrontCameraPlace.position.x + x, FrontCameraPlace.position.y + y, FrontCameraPlace.position.z);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, FrontCameraPlace.localRotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, speed * Time.deltaTime);
                }
                else
                {
                    mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, FrontCameraPlace.localPosition, step * 18);
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, FrontCameraPlace.localRotation, step);
                    mainCamera.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 55, speed * Time.deltaTime);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                backCamera = !backCamera;
            }

        } 

    }

    public void RunChangeStatus()
    {
        runON = !runON;
    }
}
