using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingTriggerStartScript : MonoBehaviour
{
    public float speed;
    public float posZ;

    private void Start()
    {
        speed = 0;
        posZ = 0;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, posZ), speed * Time.deltaTime);
    }
}
