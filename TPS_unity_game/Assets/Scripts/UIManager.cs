using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool runON;
    public bool pauseON;
    public GameObject HPBar;
    private RectTransform sliderTransform;
    private Vector2 sliderPos;
    
    public GameObject distance;
    private RectTransform distanceTransform;
    private Vector2 distancePos;
    private TMP_Text distanceText;

    public GameObject distanceTriggerObject;
    private DistanceTrigger distTr;

    public float speed;

    [Header("HPSiderPositionX")]
    public float hpONPosX;
    public float hpOFFPosX;

    [Header("HPSiderPositionY")]
    public float hpONPosY;
    public float hpOFFPosY;

    [Header("DistancePositionX")]
    public float distONPosX;
    public float distOFFPosX;

    [Header("DistancePositionY")]
    public float distONPosY;
    public float distOFFPosY;
    
    [Header("BiomePositionX")]
    public float biomeONPosX;
    public float biomeOFFPosX;

    [Header("BiomePositionY")]
    public float biomeONPosY;
    public float biomeOFFPosY;
    
    [Header("HintsPositionX")]
    public float hintsONPosX;
    public float hintsOFFPosX;

    [Header("HintsPositionY")]
    public float hintsONPosY;
    public float hintsOFFPosY;

    public GameObject biomeObject;
    private RectTransform biomeTransform;
    private Vector2 biomePos;
    private TMP_Text biomeText;
    public bool showBiome;

    public GameObject playerObject;
    private PlayerHealth playerHP;
    private Slider HPSlider;

   
    public GameObject gameControllerObject;
    private GameController gameCtr;

    public GameObject hintsObject;
    private RectTransform hintsTransform;
    private Vector2 hintsPos;
    public int showHints;

    void Start()
    {
        runON = false;
        pauseON = false;
        sliderTransform = HPBar.GetComponent<RectTransform>();
        sliderPos = sliderTransform.anchoredPosition;

        distanceTransform = distance.GetComponent<RectTransform>();
        distancePos = distanceTransform.anchoredPosition;

        distTr = distanceTriggerObject.GetComponent<DistanceTrigger>();
        distanceText = distance.GetComponent<TMP_Text>();

        playerHP = playerObject.GetComponent<PlayerHealth>();
        HPSlider = HPBar.GetComponent<Slider>();

        gameCtr = gameControllerObject.GetComponent<GameController>();

        biomeText = biomeObject.GetComponent<TMP_Text>();
        biomeTransform = biomeObject.GetComponent<RectTransform>();
        biomePos = biomeTransform.anchoredPosition;
        showBiome = false;

        showHints = PlayerPrefs.GetInt("hintsON");
        hintsTransform = hintsObject.GetComponent<RectTransform>();
        hintsPos = hintsTransform.anchoredPosition;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        distanceText.text = "Distance " + distTr.distanceScaled.ToString() + "m";
        if (showBiome)
        {
            biomeObject.transform.localPosition = Vector3.MoveTowards(biomeObject.transform.localPosition, new Vector3(biomePos.x + biomeONPosX , biomePos.y + biomeONPosY), step * 30);
            Invoke(nameof(BiomeTextHide), 4f);
        }
        else
        {
            biomeObject.transform.localPosition = Vector3.MoveTowards(biomeObject.transform.localPosition, new Vector3(biomePos.x + biomeOFFPosX, biomePos.y + biomeOFFPosY), step * 30);
        }

        if (runON && !pauseON)
        {
            //SliderHP.transform.localPosition = Vector3.MoveTowards(new Vector3(sliderPos.x + runOFFPositionX, sliderPos.y + runOFFPositionY), new Vector3(sliderPos.x + runONPositionX, sliderPos.y + runONPositionY),speed);
            
            HPBar.transform.localPosition = Vector3.MoveTowards(HPBar.transform.localPosition, new Vector3(sliderPos.x + hpONPosX, sliderPos.y + hpONPosY), step * 100);
            distance.transform.localPosition = Vector3.MoveTowards(distance.transform.localPosition, new Vector3(distancePos.x + distONPosX, distancePos.y + distONPosY), step * 100);
            
        }
        else
        {
            //SliderHP.transform.localPosition = Vector3.MoveTowards(new Vector3(sliderPos.x + runONPositionX, sliderPos.y +  runONPositionY), new Vector3(sliderPos.x + runOFFPositionX, sliderPos.y +  runOFFPositionY), speed);
            HPBar.transform.localPosition = Vector3.MoveTowards(HPBar.transform.localPosition, new Vector3(sliderPos.x + hpOFFPosX, sliderPos.y + hpOFFPosY), step * 100);
            distance.transform.localPosition = Vector3.MoveTowards(distance.transform.localPosition, new Vector3(distancePos.x + distOFFPosX, distancePos.y + distOFFPosY), step * 100);

        }
        HPSlider.value = playerHP.currentHealth;
        if (playerHP.dead)
        {
            gameCtr.gameOver = true;
            gameCtr.distanceTraveled = distTr.distanceScaled;
        }

        if (showHints == 1 && runON && !pauseON)
        {
            hintsObject.transform.localPosition = Vector3.MoveTowards(hintsObject.transform.localPosition, new Vector3(hintsPos.x + hintsONPosX, hintsPos.y + hintsONPosY), step * 100);
        }
        else
        {
            hintsObject.transform.localPosition = Vector3.MoveTowards(hintsObject.transform.localPosition, new Vector3(hintsPos.x + hintsOFFPosX, hintsPos.y + hintsOFFPosY), step * 100);
        }
    }
    public void RunChangeStatus()
    {
        runON = !runON;
    }

    public void ChangeBiomeText()
    {
        biomeText.text = "Biome: " + PlayerPrefs.GetString("currentBiome");
    }

    public void BiomeTextShowUP()
    {
        showBiome = true;
    }
    public void BiomeTextHide()
    {
        showBiome = false;
    }
    
    public void ChangeHintsStatus()
    {
        showHints = PlayerPrefs.GetInt("hintsON");
    }
}
