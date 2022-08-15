using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    public float jumpForce;
    public float speed = 2f;
    private Transform[] lanes = new Transform[3];
    private int activeLane;
    public Transform lane0;
    public Transform lane1;
    public Transform lane2;

    void Start()
    {
        activeLane = 1;
        rb = GetComponent<Rigidbody>();
        lanes[0] = lane0;
        lanes[1] = lane1;
        lanes[2] = lane2;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        var movementHor = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(movementHor * movementSpeed, rb.velocity.y, 0);
        */

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //gameObject.transform.position += new Vector3(-2.5f, 0f);
            if (activeLane != 0)
            {
                activeLane -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //gameObject.transform.position += new Vector3(2.5f, 0f);
            //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(20f, 0f));
            //transform.position += new Vector3(2.5f, 0f, 0f) * Time.deltaTime;
            //GetComponent<Rigidbody>().velocity = new Vector2(0, floatingVelocity);
            //transform.position + new Vector3(2.5f, 0f, 0f)

            if (activeLane + 1 != lanes.Length)
            {
                activeLane += 1;
            }
        }

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, lanes[activeLane].position , step);
    
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    public void Jump()
    {
        //rb.velocity = Vector2.up * silaSkoku;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
