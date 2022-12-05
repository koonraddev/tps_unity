using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    private int lightsON;

    private GameObject haloObject;
    private GameObject lightObject;
    private GameObject glassObject;

    void Start()
    {
        haloObject = gameObject.transform.GetChild(0).gameObject;
        lightObject = gameObject.transform.GetChild(1).gameObject;
        glassObject = gameObject.transform.GetChild(2).gameObject;
    }
    void Update()
    {
        lightsON = PlayerPrefs.GetInt("lightsON");
        if (lightsON == 1)
        {
            haloObject.SetActive(true);
            lightObject.SetActive(true);
            //glassObject.SetActive(true);
        }
        else
        {
            haloObject.SetActive(false);
            lightObject.SetActive(false);
            //glassObject.SetActive(false);
        }
    }
}
