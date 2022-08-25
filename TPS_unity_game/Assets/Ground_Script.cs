using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Script : MonoBehaviour
{
    private float planeSpeed;
    public float baseSpeed;
    public float runSpeed;

    void Update()
    {
        transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime * planeSpeed;
    }

    public void SpeedUp()
    {
        planeSpeed = runSpeed;
    }

    public void SpeedDown()
    {
        planeSpeed = baseSpeed;
    }
}
