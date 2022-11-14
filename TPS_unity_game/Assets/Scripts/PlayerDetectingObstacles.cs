using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectingObstacles : MonoBehaviour
{
    CharacterController ctr;


    private void Update()
    {
       // Debug.Log(ctr.detectCollisions.ToString());
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        //Debug.Log(other.gameObject.name);

    }
}
