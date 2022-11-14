using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTrigger : MonoBehaviour
{
    public GameObject cam;
    private CameraStartMenu camCtr;
    public GameObject quitMenu;
    public Transform quitCameraPlace;
    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();
    }

    void Update()
    {
        if (cam.transform.position == quitCameraPlace.position)
        {
            quitMenu.SetActive(true);
        }
        else
        {
            quitMenu.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        camCtr.QuitCameraPlace(); ;
    }
}
