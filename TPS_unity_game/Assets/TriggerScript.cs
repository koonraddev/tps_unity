using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject groundPrefab;
    private float positonZ;
    private float addPositionZ;

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
        positonZ = groundPrefab.GetComponent<BoxCollider>().size.z / 2;
        Vector3 pos1 = gameObject.transform.position + (new Vector3(0f, 0f, positonZ));
        Instantiate(groundPrefab, pos1, Quaternion.identity);
    }
}
