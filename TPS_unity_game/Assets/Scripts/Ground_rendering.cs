using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_rendering : MonoBehaviour
{

    public GameObject groundPrefab;
    private float positonZ;
    private float addPositionZ;
    void Start()
    {
        InvokeRepeating("RenderGround", 1f,1f);
        addPositionZ = gameObject.GetComponent<BoxCollider>().size.z;
    }

    private void RenderGround()
    {
        Vector3 pos1 = groundPrefab.transform.position + (new Vector3(0f, 0f, positonZ));
        Instantiate(groundPrefab, pos1, Quaternion.Euler(0f,0f,0f));
        positonZ += addPositionZ;
    }

}
