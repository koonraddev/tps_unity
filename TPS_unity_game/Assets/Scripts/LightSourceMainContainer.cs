using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceMainContainer : MonoBehaviour
{
    public float totalSeconds;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    private Light myLight;        // Your light

    private bool changeColor;

    private int colorIndex;
    public Color[] colorList;


    private void Start()
    {
        myLight = gameObject.GetComponent<Light>();
        colorIndex = 0;
        changeColor = false;
        myLight.color = colorList[colorIndex];

    }
    private void Update()
    {
        if (myLight.intensity == 0 && changeColor == true)
        {
            if (colorIndex == colorList.Length - 1)
            {
                colorIndex = 0;
            }
            else
            {
                colorIndex += 1;
            }
            changeColor = false;
        }

        myLight.color = colorList[colorIndex];

        if (myLight.intensity == 0 || myLight.intensity == maxIntensity)
        {
            StopCoroutine(flashNow());
            StartCoroutine(flashNow());
        }

    }

    public IEnumerator flashNow()
    {
        changeColor = true;
        float waitTime = totalSeconds / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)
        while (myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
            yield return null;
        }
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;         //Decrease intensity
            yield return null;
        }

        yield return null;
    }

    public int randomIntExcept(int except)
    {
        int result = Random.Range(0, colorList.Length - 1);
        if (result >= except) result += 1;
        return result;
    }

}
