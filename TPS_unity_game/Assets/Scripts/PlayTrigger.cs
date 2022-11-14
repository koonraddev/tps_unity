using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrigger : MonoBehaviour
{
    public GameObject cam;
    private CameraStartMenu camCtr;

    public GameObject leftRenderingTrigger;
    private RenderingTriggerStartScript leftRTSS;

    public GameObject rightRenderingTrigger;
    private RenderingTriggerStartScript rightRTSS;

    public GameObject mainRenderingTrigger;
    private RenderingTriggerStartScript mainRTSS;

    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();

        leftRTSS = leftRenderingTrigger.GetComponent<RenderingTriggerStartScript>();
        rightRTSS = rightRenderingTrigger.GetComponent<RenderingTriggerStartScript>();
        mainRTSS = mainRenderingTrigger.GetComponent<RenderingTriggerStartScript>();
    }

    public void OnMouseDown()
    {
        camCtr.PlayCameraPlace();
        leftRTSS.ChangeTriggerPosition();
        rightRTSS.ChangeTriggerPosition();
        mainRTSS.ChangeTriggerPosition();
        Ground_Script[] groundObjects = FindObjectsOfType<Ground_Script>();

        foreach(Ground_Script obj in groundObjects)
        {
            obj.MoveObject();
        }
    }
}
