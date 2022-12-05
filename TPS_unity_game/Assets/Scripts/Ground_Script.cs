using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Script : MonoBehaviour
{
    private GameSettings gameSettings;


    private float planeSpeed;
    private float baseSpeed;
    private float runSpeed;
    public bool freeze;
    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        if (!freeze)
        {
            MoveObject();
        }
        else
        {
            FreezeObject();
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunSpeed();
        }
        else
        {
            BaseSpeed();
        }
        transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime * planeSpeed;
    }

    public void RunSpeed()
    {
        planeSpeed = runSpeed;
    }

    public void BaseSpeed()
    {
        planeSpeed = baseSpeed;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void FreezeObject()
    {
        baseSpeed = 0;
        runSpeed = 0;
    }
    public void MoveObject()
    {
        baseSpeed = gameSettings.GetBaseSpeed();
        runSpeed = gameSettings.GetRunSpeed();
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public float GetRunSpeed()
    {
        return runSpeed;
    }
}
