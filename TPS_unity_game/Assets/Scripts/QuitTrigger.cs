using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class QuitTrigger : MonoBehaviour
{
    public GameObject cam;
    private CameraStartMenu camCtr;
    public GameObject quitMenu;
    public Transform quitCameraPlace;


    public GameObject playTextObject;
    private TMP_Text quitText;

    public GameObject lightQuit;
    public bool lightMustBeON;
    private bool lightsON;
    private int dayTime;

    [Header("Colors")]
    public Color basicColor;
    public Color mouseOnColor;
    public float changeDuration;
    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();
        quitText = playTextObject.GetComponent<TMP_Text>();
        quitText.color = basicColor;
        lightMustBeON = false;
    }

    void Update()
    {
        dayTime = PlayerPrefs.GetInt("dayTime");
        if ((dayTime == 3 || dayTime == 4) && PlayerPrefs.GetInt("lightsON") == 1)
        {
            lightsON = true;
        }
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
        camCtr.QuitCameraPlace();
        if (lightsON)
        {
            lightQuit.SetActive(true);
        }
        lightMustBeON = true;
    }

    private void OnMouseEnter()
    {
        quitText.DOColor(mouseOnColor, changeDuration);
        if (lightsON)
        {
            lightQuit.SetActive(true);
        }

    }

    private void OnMouseExit()
    {
        quitText.DOColor(basicColor, changeDuration);
        if (!lightMustBeON)
        {
            lightQuit.SetActive(false);
        }
    }

    public void LightOff()
    {
        lightMustBeON = false;
    }
}
