using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectingObstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider enterInfo)
    {
        if (enterInfo.tag == "Obstacle")
        {
            Destroy(enterInfo.gameObject);
        }
    }
}
