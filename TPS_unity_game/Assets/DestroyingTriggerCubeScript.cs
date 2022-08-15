using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingTriggerCubeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider enterInfo)
    {
        if (enterInfo.tag == "Plane")
        {
            Destroy(enterInfo.gameObject);
        }
    }
}
