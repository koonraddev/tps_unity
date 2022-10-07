using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrigger : MonoBehaviour
{
    public GameObject cam;
    private CameraStartMenu camCtr;

    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();
    }

    public void OnMouseDown()
    {
        camCtr.PlayCameraPlace();
        Ground_Script[] groundObjects = FindObjectsOfType<Ground_Script>();

        foreach(Ground_Script obj in groundObjects)
        {
            obj.MoveObject();
        }
    }
}
