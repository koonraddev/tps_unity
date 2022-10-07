using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 movVect;
    private float movHorizontal;
    private float movVertical;

    public CharacterController ctr;



    private Transform[] lanes = new Transform[5];
    private int activeLane;
    public Transform lane0;
    public Transform lane1;
    public Transform lane2;
    public Transform lane3;
    public Transform lane4;

    public bool backCamera;

    private float movementSpeed;
    public float movementSpeedOnGround;
    public float movementSpeedInAir;
    public float jumpForce;
    public float gravity;
    public float verticalVelocity;
    private float stepPlayer;
    private Vector3 newPosition = Vector3.zero;

    void Start()
    {
        activeLane = 2;
        lanes[0] = lane0;
        lanes[1] = lane1;
        lanes[2] = lane2;
        lanes[3] = lane3;
        lanes[4] = lane4;
        stepPlayer = movementSpeed * Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (backCamera)
            {
                activeLane -= 1;
            }
            else
            {
                activeLane += 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (backCamera)
            {
                activeLane += 1;
            }
            else
            {
                activeLane -= 1;
            }

        }
        activeLane = Mathf.Clamp(activeLane, 0, 4);


        movHorizontal = Input.GetAxisRaw("Horizontal");
        movVect = new Vector3(movHorizontal, 0f, 0f);

        if (ctr.isGrounded)
        {
            movementSpeed = movementSpeedOnGround;
            verticalVelocity = -0.1f;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            movementSpeed = movementSpeedInAir;
            verticalVelocity -= (gravity * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                verticalVelocity = -jumpForce;
            }
        }       
        newPosition.x = lanes[activeLane].transform.position.x;

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (newPosition - transform.position).normalized.x * movementSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = 0f;
        ctr.Move(moveVector * Time.deltaTime);
    }

    public void Jump()
    {
        
    }
    public int GetActiveLane()
    {
        return activeLane;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
}
