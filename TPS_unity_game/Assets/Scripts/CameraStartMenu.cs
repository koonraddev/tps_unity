using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartMenu : MonoBehaviour
{
    public Camera mainCamera;

    public bool menuActive;
    public int lineVertexCount = 25;
    public float lineLength = 2f;
    public float lineScaleXMenu = 2f;
    public float lineScaleYMenu = 2f;
    public float frequencyMenu = 1f;

    private Transform[] menuCameraPlaces = new Transform[4];

    public Transform mainCameraPlace;
    public Transform playCameraPlace;
    public Transform optionsCameraPlace;
    public Transform quitCameraPlace;
    public float speed;

    public int activeCamera;

    public bool runOFF;

    public bool cameraIdle;
    //1 main
    //2 play/run
    //3 options
    //4 quit
    void Start()
    {
        runOFF = true;
        activeCamera = 0;
        cameraIdle = true;
        menuCameraPlaces[0] = mainCameraPlace;
        menuCameraPlaces[1] = playCameraPlace;
        menuCameraPlaces[2] = optionsCameraPlace;
        menuCameraPlaces[3] = quitCameraPlace;
    }

    // Update is called once per frame
    void Update()
    {
        if (runOFF)
        {
            var step = speed * Time.deltaTime;
            float sineWave = Mathf.PI * lineLength;
            float angleOffset = sineWave / (lineVertexCount - 1);

            for (int i = lineVertexCount; i-- > 0;)
            {
                float angleMenu = angleOffset * i;
                float xMenu = Mathf.Cos(angleMenu + Time.time * frequencyMenu) * lineScaleXMenu;
                float yMenu = (Mathf.Sin(2 * (angleMenu + Time.time * frequencyMenu)) / 2) * lineScaleYMenu;

                if (activeCamera == 0)
                {
                    if (mainCamera.transform.position == menuCameraPlaces[0].position)
                    {
                        cameraIdle = true;
                    }
                }
                else
                {
                    cameraIdle = false;
                }

                if (cameraIdle)
                {
                    mainCamera.transform.position = new Vector3(menuCameraPlaces[activeCamera].position.x + xMenu, menuCameraPlaces[activeCamera].position.y + yMenu, menuCameraPlaces[activeCamera].position.z);
                }
                mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, menuCameraPlaces[activeCamera].position, step * 10);
                mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, menuCameraPlaces[activeCamera].localRotation, step * 2);
            }
        }
    }

    public void MainCameraPlace()
    {
        activeCamera = 0;
    }

    public void PlayCameraPlace()
    {
        activeCamera = 1;
    }

    public void OptionsCameraPlace()
    {
        activeCamera = 2;
    }

    public void QuitCameraPlace()
    {
        activeCamera = 3;
    }

    public void RunChangeStatus()
    {
        runOFF = !runOFF;
    }
}