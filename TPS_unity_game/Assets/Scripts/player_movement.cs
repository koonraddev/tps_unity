using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    public float fallingForce;
    public float jumpForce;
    private Transform[] lanes = new Transform[3];
    private int activeLane;
    public Transform lane0;
    public Transform lane1;
    public Transform lane2;

    public bool backCamera;
    public bool playerOnGround;
    public bool playerFalling;
    public bool playerJumping;

    private GameObject groundVariable;
    private GameObject[] objects;

    private float stepPlayer;
    private Vector3 newPosition;
    void Start()
    {
        activeLane = 1;
        rb = GetComponent<Rigidbody>();
        lanes[0] = lane0;
        lanes[1] = lane1;
        lanes[2] = lane2;
        backCamera = true;
        groundVariable = (GameObject)Resources.Load("Cube", typeof(GameObject));
        stepPlayer = movementSpeed * Time.deltaTime;
        newPosition = new Vector3(lanes[activeLane].position.x, lanes[activeLane].position.y, 0f);
        MovePlayer();
    }
    void Update()
    {
        newPosition = new Vector3(lanes[activeLane].position.x, lanes[activeLane].position.y, 0f);

        UpdatePlayerMovementStatus();
        
        if (playerOnGround) // player on ground
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (backCamera)
                {
                    if (activeLane != 0)
                    {
                        activeLane -= 1;
                    }
                }
                else
                {
                    if (activeLane + 1 != lanes.Length)
                    {
                        activeLane += 1;
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (backCamera)
                {
                    if (activeLane + 1 != lanes.Length)
                    {
                        activeLane += 1;
                    }
                }
                else
                {
                    if (activeLane != 0)
                    {
                        activeLane -= 1;
                    }
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                stepPlayer = 0;
                
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        if (playerFalling) //player falling 
        {
            transform.position += new Vector3(0, -1, 0) * Mathf.Abs(rb.velocity.y) * Time.deltaTime * fallingForce;
        }

        if (!playerOnGround) //player is not on ground
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                stepPlayer = 0;
            }
        }

        if (stepPlayer < 1)
        {
            MovePlayer();
            if (transform.position.x == lanes[activeLane].position.x)
            {
                stepPlayer += 1;
            }
            Debug.Log("Moooooving" + stepPlayer);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            groundVariable.GetComponent<Ground_Script>().SpeedUp();
            
            objects = GameObject.FindGameObjectsWithTag("Plane");
            foreach (GameObject oneObject in objects)
            {
                oneObject.GetComponent<Ground_Script>().SpeedUp();
            }
        }
        else
        {
            groundVariable.GetComponent<Ground_Script>().SpeedDown();
            objects = GameObject.FindGameObjectsWithTag("Plane");
            foreach (GameObject oneObject in objects)
            {
                oneObject.GetComponent<Ground_Script>().SpeedDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            backCamera = !backCamera;  
        }   

    }

    public void UpdatePlayerMovementStatus()
    {
        if (rb.velocity.y == 0)
        {
            playerOnGround = true;
        }
        else
        {
            playerOnGround = false;
            if (rb.velocity.y < 0)
            {
                playerFalling = true;
                playerJumping = false;
            }
            else
            {
                playerFalling = false;
                playerJumping = true;
            }
        }
    }

    public void Jump()
    {
        if (stepPlayer > 1)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void MovePlayer()
    {
        stepPlayer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, movementSpeed * stepPlayer);
    }

    public int GetActiveLane()
    {
        return activeLane;
    }

    
}
