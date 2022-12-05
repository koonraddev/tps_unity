using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class OptionsTrigger : MonoBehaviour
{
    public Camera cam;
    private CameraStartMenu camCtr;
    public GameObject optionsMenu;
    public Transform optionsCameraPlace;
    public GameObject optionsTextObject;
    private TMP_Text optionsText;

    public GameObject laptopOFF;
    public GameObject laptopON;
    public GameObject lightOptions;

    public bool lightMustBeON;
    private bool lightsON;
    private int dayTime;

    public float speed;
    [Header("Colors")]
    public Color basicColor;
    public Color mouseOnColor;
    public float changeDuration;
   
    void Start()
    {
        camCtr = cam.GetComponent<CameraStartMenu>();
        optionsText = optionsTextObject.GetComponent<TMP_Text>();
        optionsText.color = basicColor;
        lightMustBeON = false;
    }

    void Update()
    {
        dayTime = PlayerPrefs.GetInt("dayTime");
        if ((dayTime == 3 || dayTime == 4) && PlayerPrefs.GetInt("lightsON") == 1)
        {
            lightsON = true;
        }
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
        if (lightsON)
        {
            lightOptions.SetActive(true);
        }
        lightMustBeON = true;
    }

    private void OnMouseEnter()
    {
        if (lightsON)
        {
            lightOptions.SetActive(true);
        }
        optionsText.DOColor(mouseOnColor, changeDuration);
        laptopON.SetActive(true);
        laptopOFF.SetActive(false);
    }

    private void OnMouseExit()
    {
        optionsText.DOColor(basicColor, changeDuration);
        laptopON.SetActive(false);
        if (!lightMustBeON)
        {
            lightOptions.SetActive(false);
        }

        laptopOFF.SetActive(true);
    }

    public void LightOff()
    {
        lightMustBeON = false;
    }
}
