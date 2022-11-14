using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsTrigger : MonoBehaviour
{
    public Camera cam;
    private CameraStartMenu camCtr;
    public GameObject optionsMenu;
    public Transform optionsCameraPlace;
    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();
    }

    void Update()
    {
        if (cam.transform.position == optionsCameraPlace.position)
        {
            optionsMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        camCtr.OptionsCameraPlace();
    }
}
