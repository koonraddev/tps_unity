using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingTriggerStartScript : MonoBehaviour
{
    public float speed;
    public float posZ;

    private float actualSpeed;
    private float actualPosZ;


    private void Start()
    {
        actualSpeed = 0;
        actualPosZ = 0;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, actualPosZ), actualSpeed * Time.deltaTime);
    }

    public void ChangeTriggerPosition()
    {
        actualSpeed = speed;
        actualPosZ = posZ;
    }
}
