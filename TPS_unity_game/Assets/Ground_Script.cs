using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Script : MonoBehaviour
{
    public float planeSpeed;
    void Update()
    {
        transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime * planeSpeed;
    }
}
