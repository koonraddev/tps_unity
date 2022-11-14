using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public int difficulty;

    public bool hintsON;

    public float musicVolume;
    public float soundVolume;

    public int resWidth;
    public int resHeight;


    void Start()
    {
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetInt("difficulty", 0);
            difficulty = PlayerPrefs.GetInt("difficulty");
        }
        else
        {
            difficulty = PlayerPrefs.GetInt("difficulty");

        }
    }

    private void Update()
    {
        
    }

    public void SetDifficulty(int difficultyValue)
    {
        difficulty = difficultyValue;
     
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


}
