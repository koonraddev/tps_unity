using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public GameObject blackScreenObject;
    public GameObject logoObject;
    public GameObject robot;

    public float fadingTime;

    private Image blackImage;
    private Image logoImage;

    private Color blackOpaque = Color.black;
    private Color blackTransparent = Color.black;

    void Start()
    {
        blackImage = blackScreenObject.GetComponent<Image>();
        logoImage = logoObject.GetComponent<Image>();
        blackTransparent.a = 0f;
        Invoke(nameof(FadeOutLogoScreen), 6f);
        Invoke(nameof(FadeOutBlackScreen), 8f);
        CheckPlayerPrefs();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && logoImage.color.a == 0f)
        {
            FadeInBlackScreen();
        }
    }

    public void FadeOutBlackScreen() //zanikanie
    {
        blackImage.DOColor(blackTransparent, fadingTime);
        robot.SetActive(true);
        
    }

    public void FadeOutLogoScreen()
    {
        logoImage.DOFade(0f, 2f);
    }

    public void FadeInBlackScreen() //pojawianie
    {
        blackImage.DOColor(blackOpaque, fadingTime);
        Invoke("LoadMainScene",fadingTime);

    }

    public void LoadMainScene()
    {
        blackImage.DOPause();
        SceneManager.LoadScene(1);
    }

    public void CheckPlayerPrefs()
    {
        //Hinst
        if (!PlayerPrefs.HasKey("hintsON"))
        {
            PlayerPrefs.SetInt("hintsON", 1);
        }

        //Difficulty
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetInt("difficulty", 0);
        }

        //Day Time
        if (!PlayerPrefs.HasKey("dayTime"))
        {
            PlayerPrefs.SetInt("dayTime", 2);
        }
        //Day Time Sun Position (Animation Time)
        if (!PlayerPrefs.HasKey("sunAnimTime"))
        {
            PlayerPrefs.SetFloat("sunAnimTime", 0f);
        }

        //Lights ON
        if (!PlayerPrefs.HasKey("lightsON"))
        {
            PlayerPrefs.SetInt("LightsON", 0);
        }

        //Music Volume
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 75);
        }

        //Sound Volume
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 100);
        }

        //Resolution Width
        if (!PlayerPrefs.HasKey("resolutionWidth"))
        {
            PlayerPrefs.SetInt("resolutionWidth", 1600);
        }

        //Resolution Height
        if (!PlayerPrefs.HasKey("resolutionHeight"))
        {
            PlayerPrefs.SetInt("resolutionHeight", 900);
        }

        //Fullscreen
        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }

        //Distance Traveled
        if (!PlayerPrefs.HasKey("distanceTraveled"))
        {
            PlayerPrefs.SetInt("distanceTravelde", 0);
        }

        //HighScore
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }

        //Current Biome
        if (!PlayerPrefs.HasKey("currentBiome"))
        {
            PlayerPrefs.SetString("currentBiome", "Industry");
        }

        //Object Number
        if (!PlayerPrefs.HasKey("numberObject"))
        {
            PlayerPrefs.SetInt("numberObject", 1);
        }

        //Run On
        if (!PlayerPrefs.HasKey("runON"))
        {
            PlayerPrefs.SetInt("runON", 0);
        }

        //Player Dead
        if (!PlayerPrefs.HasKey("playerDead"))
        {
            PlayerPrefs.SetInt("playerDead", 0);
        }

        //Play Again
        if (!PlayerPrefs.HasKey("playAgain"))
        {
            PlayerPrefs.SetInt("playAgain", 0);
        }

    }
}
