using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLight : MonoBehaviour
{
    private bool lightsON;
    private int dayTime;

    private GameObject lightObject;
    void Start()
    {
        lightObject = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        dayTime = PlayerPrefs.GetInt("dayTime");
        if (dayTime == 2 || dayTime == 3)
        {
            lightsON = true;
        }
        else
        {
            lightsON = false;
        }

        if (lightsON)
        {
            lightObject.SetActive(true);
        }
        else
        {
            lightObject.SetActive(false);
        }
    }
}
