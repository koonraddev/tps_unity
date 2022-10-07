using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsTrigger : MonoBehaviour
{
    public GameObject cam;
    private CameraStartMenu camCtr;
    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();
    }

    public void OnMouseDown()
    {
        camCtr.OptionsCameraPlace();
    }
}
