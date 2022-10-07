using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public int difficulty;

    public void SetEasy()
    {
        difficulty = 1;
    }

    public void SetMedium()
    {
        difficulty = 2;
    }

    public void SetHard()
    {
        difficulty = 3;
    }

    public int GetBaseSpeed()
    {
        if (difficulty == 1)
        {
            return 10; //easy
        }
        else
        {
            if (difficulty == 2)
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
        if (difficulty == 1)
        {
            return 15;//easy
        }
        else
        {
            if (difficulty == 2)
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
