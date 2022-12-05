using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    public GameObject g1;
    public float baseXpos;
    public float baseYpos;
    public float baseZpos;

    public int distanceScaled;
    public int metersHolder;
    public int distINT;
    void Start()
    {
        distanceScaled = 0;
        metersHolder = 0;
        baseXpos = g1.transform.position.x;
        baseYpos = g1.transform.position.y;
        baseZpos = g1.transform.position.z;
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, g1.transform.position);
        distINT = (int)Mathf.Round(dist);

        if (distINT >=100f)
        {
            gameObject.transform.position = new Vector3(baseXpos, baseYpos, baseZpos);
            metersHolder += 50;
            distanceScaled = metersHolder;
        }
        else
        {
            distanceScaled = metersHolder + (distINT) / 2;
        }
    }

}
