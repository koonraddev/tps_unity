using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject groundPrefab;

    private void OnTriggerExit(Collider exitInfo)
    {
        Ground_Script ground = exitInfo.GetComponent<Ground_Script>();

        if (ground != null)
        {
            RenderGround();
        }
    }

    private void RenderGround()
    {
        Vector3 pos1 = gameObject.transform.position + (new Vector3(0f, 0f, groundPrefab.transform.localScale.z / 2));
        Instantiate(groundPrefab, pos1, Quaternion.identity);
        /*
        Debug.Log("game:" + gameObject.transform.position);
        Debug.Log("ground: " + groundPrefab.transform.position);
        Debug.Log("Time: " + Time.deltaTime);
        Debug.Log(pos1);
        */

    }
}
