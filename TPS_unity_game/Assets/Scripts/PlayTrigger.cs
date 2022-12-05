using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class PlayTrigger : MonoBehaviour
{
    public GameObject playerObject;
    private Animator animator;

    public GameObject cam;
    private CameraStartMenu camCtr;

    public GameObject leftRenderingTrigger;
    private RenderingTriggerStartScript leftRTSS;

    public GameObject rightRenderingTrigger;
    private RenderingTriggerStartScript rightRTSS;

    public GameObject mainRenderingTrigger;
    private RenderingTriggerStartScript mainRTSS;


    public GameObject startDoorsTriggerObj;
    private StartDoorsTrigger startDTrigger;

    public GameObject playTextObject;
    private TMP_Text playText;

    public GameObject lightPlay;
    public bool lightMustBeON;
    private bool lightsON;
    private int dayTime;

    [Header("Colors")]
    public Color basicColor;
    public Color mouseOnColor;
    public float changeDuration;

    void Start()
    {
        animator = playerObject.GetComponent<Animator>();
        camCtr = cam.GetComponent<CameraStartMenu>();

        leftRTSS = leftRenderingTrigger.GetComponent<RenderingTriggerStartScript>();
        rightRTSS = rightRenderingTrigger.GetComponent<RenderingTriggerStartScript>();
        mainRTSS = mainRenderingTrigger.GetComponent<RenderingTriggerStartScript>();

        playText = playTextObject.GetComponent<TMP_Text>();
        playText.color = basicColor;

        startDTrigger = startDoorsTriggerObj.GetComponent<StartDoorsTrigger>();
        lightMustBeON = false;
        Invoke(nameof(PlayAgainCheck), 1f);
    }

    private void Update()
    {
        dayTime = PlayerPrefs.GetInt("dayTime");
        if ((dayTime == 3 || dayTime == 4) && PlayerPrefs.GetInt("lightsON")== 1)
        {
            lightsON = true;
        }
    }

    public void PlayAgainCheck()
    {
        if (PlayerPrefs.GetInt("playAgain") == 1)
        {
            OnMouseDown();
            PlayerPrefs.SetInt("playAgain", 0);
        }
    }

    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("runON", 1);
        camCtr.PlayCameraPlace();
        leftRTSS.ChangeTriggerPosition();
        rightRTSS.ChangeTriggerPosition();
        mainRTSS.ChangeTriggerPosition();
        Ground_Script[] groundObjects = FindObjectsOfType<Ground_Script>();
        lightMustBeON = true;
        //Cursor.visible = false;
        int difficulty = PlayerPrefs.GetInt("difficulty");

        switch (difficulty)
        {
            case 0:
                animator.speed = 1f;
                break;
            case 1:
                animator.speed = 1.5f;
                break;
            case 2:
                animator.speed = 2f;
                break;
        }
        foreach (Ground_Script obj in groundObjects)
        {
            obj.MoveObject();
        }
    }

    private void OnMouseEnter()
    {
        playText.DOColor(mouseOnColor, changeDuration);
        startDTrigger.ChangeDoorsStatus();
        if (lightsON)
        {
            lightPlay.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        playText.DOColor(basicColor, changeDuration);
        startDTrigger.ChangeDoorsStatus();
        if (!lightMustBeON)
        {
            lightPlay.SetActive(false);
        }
    }
}
