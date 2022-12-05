using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSettings : MonoBehaviour
{
    private int difficulty;

    private int hintsON; //1 - on; 0 - off
    private int fullscreenON; //1 - on; 0 - off

    private float musicVolume;
    private float soundVolume;
    private int resWidth;
    private int resHeight;

    private int dayTime;
    private


    void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
        hintsON = PlayerPrefs.GetInt("hintsON");
        fullscreenON = PlayerPrefs.GetInt("fullscreen");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        soundVolume = PlayerPrefs.GetFloat("soundVolume");
        resWidth = PlayerPrefs.GetInt("resolutionWidth");
        resHeight = PlayerPrefs.GetInt("resolutionHeight");
        dayTime = PlayerPrefs.GetInt("dayTime");
    }

    private void Update()
    {
        
    }

    public void SetDifficulty(int difficultyValue)
    {
        difficulty = difficultyValue;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
    public int GetBaseSpeed()
    {
        if (difficulty == 0)
        {
            return 10; //easy
        }
        else
        {
            if (difficulty == 1)
            {
                return 15;//medium
            }
            else
            {
                return 20;//hard
            }
        }
    }

    public int GetRunSpeed()
    {
        if (difficulty == 0)
        {
            return 15;//easy
        }
        else
        {
            if (difficulty == 1)
            {
                return 20;//medium
            }
            else
            {
                return 25;//hard
            }
        }
    }

    public void SetHints(int hintsINT)
    {
        hintsON = hintsINT;
    }

    public int GetHints()
    {
        return hintsON;
    }

    public void SetFullscreen(int fullON)
    {
        fullscreenON = fullON;
    }
    public void SetApplyResolution(int resH, int resW)
    {
        resHeight = resH;
        resWidth = resW;
        if (fullscreenON == 1)
        {
            Screen.SetResolution(resW, resH, true);
        }
        else
        {
            Screen.SetResolution(resW, resH, false);
        }

    }

    
    public void SetDayTime(int dayTimeValue)
    {
        dayTime = dayTimeValue;
    }
    public int GetDayTime()
    {
        return dayTime;
    }
}
