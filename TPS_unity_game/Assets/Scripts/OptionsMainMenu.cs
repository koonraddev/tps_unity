using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMainMenu : MonoBehaviour
{

    

    public GameObject player;
    private GameSettings gameSets;

    public GameObject diffObj;
    private TMP_Dropdown diffDropDown;

    public GameObject hintsObj;
    private Toggle hintsToggle;

    public GameObject musicObj;
    private Slider musicSlider;

    public GameObject soundObj;
    private Slider soundSlider;

    public GameObject ressObj;
    private TMP_Dropdown ressDropDown;

    void Start()
    {
        gameSets = player.GetComponent<GameSettings>();
        diffDropDown = diffObj.GetComponent<TMP_Dropdown>();
        hintsToggle = hintsObj.GetComponent<Toggle>();
        musicSlider = musicObj.GetComponent<Slider>();
        soundSlider = soundObj.GetComponent<Slider>();
        ressDropDown = ressObj.GetComponent<TMP_Dropdown>();


        GetHints();
        GetDifficulty();
        GetGameResolution();
        GetMusic();
        GetSound();

    }

    public void OnApplyButtonClick()
    {
        var actualHintsON = hintsToggle.isOn;
        var actualDiffLevel = diffDropDown.value;
        var actualMusicVolume = musicSlider.value;
        var actualSoundVolume = soundSlider.value;
        var actualResolution = ressDropDown.value;

        
        SetHints(actualHintsON);
        SetDifficulty(actualDiffLevel);   
        SetMusic(actualMusicVolume);
        SetSound(actualSoundVolume);
        SetGameResolution(actualResolution);
    }



    public void GetHints()
    {
        if (!PlayerPrefs.HasKey("hintsON"))
        {
            var actualHintsON = hintsToggle.isOn;
            SetHints(actualHintsON);
        }
        else
        {
            int turnHintsON = PlayerPrefs.GetInt("hintsON");
            if (turnHintsON == 1)
            {
                hintsToggle.isOn = true;
            }
            else
            {
                hintsToggle.isOn = false;
            }
        }
    }

    void SetHints(bool hintsON)
    {
        //gameSets.SetHints(hintsON);
        if (hintsON)
        {
            PlayerPrefs.SetInt("hintsON", 1);
        }
        else
        {
            PlayerPrefs.SetInt("hintsON", 0);
        }
    }

    public void GetDifficulty()
    {
        int actualDifficultyLevel;
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            actualDifficultyLevel = diffDropDown.value;
            SetDifficulty(actualDifficultyLevel);
        }
        else
        {
            actualDifficultyLevel = PlayerPrefs.GetInt("difficulty");
            diffDropDown.value = actualDifficultyLevel;
        }
    }

    void SetDifficulty(int diffLevel)
    {
        //gameSets.SetDifficulty(diffLevel);
        PlayerPrefs.SetInt("difficulty", diffLevel);

    }

    public void GetGameResolution()
    {
        int actualResIndex;
        int actualResWidhtValue;
        if (!PlayerPrefs.HasKey("resolutionWidth") || !PlayerPrefs.HasKey("resolutionHeight"))
        {
            actualResIndex = ressDropDown.value;
            SetGameResolution(actualResIndex);
        }
        else
        {
            actualResWidhtValue = PlayerPrefs.GetInt("resolutionWidth");

            Dictionary<int, int> resHeightIndex = new Dictionary<int, int>()
            {
                {720, 1280 },
                {900, 1600 },
                {1080, 1920 },
                {1440, 2560 }
            };

            ressDropDown.value = resHeightIndex[actualResWidhtValue];


        }
    }

    public void SetGameResolution(int resIndex)
    {
        Dictionary<int, int> resH = new Dictionary<int, int>()
        {
            {0, 720 },
            {1, 900 },
            {2, 1080 },
            {3, 1440 }
        };

        Dictionary<int, int> resW = new Dictionary<int, int>()
        {
            {0, 1280 },
            {1, 1600 },
            {2, 1920 },
            {3, 2560 }
        };


        PlayerPrefs.SetInt("resolutionWidht", resW[resIndex]);
        PlayerPrefs.SetInt("resolutionHeight", resH[resIndex]);
        //Display.main.SetRenderingResolution(resWidht, resHeight);
    }

    public void GetMusic()
    {
        float actualMusicValue;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            actualMusicValue = musicSlider.value * 0.05f;
            SetMusic(actualMusicValue);
        }
        else
        {
            actualMusicValue = PlayerPrefs.GetFloat("musicVolume");
            musicSlider.value = (int)Mathf.Floor(actualMusicValue * 20);
        }
    }
    public void SetMusic(float musicVolume)
    {
        //gameSets.SetMusicVolume(musicVolume*0.05f);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void GetSound()
    {
        float actualSoundValue;
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            actualSoundValue = soundSlider.value * 0.05f;
            SetSound(actualSoundValue);
        }
        else
        {
            actualSoundValue = PlayerPrefs.GetFloat("soundVolume");
            soundSlider.value = (int)Mathf.Floor(actualSoundValue * 20);
        }
    }

    public void SetSound(float soundVolume)
    {
        //gameSets.SetSoundVolume(soundVolume*0.05f);
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
    }


}
