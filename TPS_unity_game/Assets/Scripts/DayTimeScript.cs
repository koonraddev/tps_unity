using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeScript : MonoBehaviour
{
    public GameObject GameController;
    private Light lightComp;
    private Animation anim;


    public Transform[] sunPlaces;
    public Color[] sunColors;
    public Color[] fogColors;

    private int sunPlaceIndex;

    public float speed;
    private bool rotationON;
    public Color fogColorAnim;
    void Start()
    {
        lightComp = gameObject.GetComponent<Light>();
        anim = gameObject.GetComponent<Animation>();
        anim.Play("SunDayNightCycle");
        SetSunPosition();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (rotationON)
        {
            anim["SunDayNightCycle"].speed = 0.005f;
            if (gameObject.transform.rotation.x >= sunPlaces[2].rotation.x-0.001)
            {
                PlayerPrefs.SetInt("lightsON", 1);
            }
            if (gameObject.transform.rotation.x <= sunPlaces[0].rotation.x + 0.001)
            {
                PlayerPrefs.SetInt("lightsON", 0);
            }
            RenderSettings.fogColor = fogColorAnim;
        }
        else
        {
            anim["SunDayNightCycle"].speed = 0f;
            lightComp.color = sunColors[sunPlaceIndex];

            switch (sunPlaceIndex)
            {
                case 0:
                    PlayerPrefs.SetFloat("sunAnimTime", 0f);
                    break;
                case 1:
                    PlayerPrefs.SetFloat("sunAnimTime", 0.25f);
                    break;
                case 2:
                    PlayerPrefs.SetFloat("sunAnimTime", 0.5f);
                    break;
                case 3:
                    PlayerPrefs.SetFloat("sunAnimTime", 0.75f);
                    break;
            }
            RenderSettings.fogColor = fogColors[sunPlaceIndex];

            anim["SunDayNightCycle"].time = PlayerPrefs.GetFloat("sunAnimTime");
        }

    }

    public void SetSunPosition()
    {
        int actualDayTime = PlayerPrefs.GetInt("dayTime");
        if (actualDayTime == 4)
        {
            rotationON = true;
            anim["SunDayNightCycle"].time = PlayerPrefs.GetFloat("sunAnimTime");
        }
        else
        {
            rotationON = false;
            sunPlaceIndex = actualDayTime;
        }
    }
}
