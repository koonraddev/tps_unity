using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingTriggerCubeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider enterInfo)
    {
        Ground_Script ground = enterInfo.GetComponent<Ground_Script>();
        if (ground != null)
        {
            Destroy(enterInfo.gameObject);
        }
    }
}
