using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public GameObject playerObject;
    private Animator animator;


    public PlayerMovement movPlayer;


    void Start()
    {

        animator = playerObject.GetComponent<Animator>();
        animator.speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("playerDead") == 0)
        {
            if (PlayerPrefs.GetInt("runON") == 1)
            {
                animator.SetBool("startRunON", true);

                if (movPlayer.ctr.isGrounded)
                {
                    animator.SetBool("jumpON", false);
                    animator.SetBool("fallON", false);
                    animator.SetBool("runON", true);

                }
                else
                {
                    if (movPlayer.verticalVelocity > 0)
                    {
                        animator.SetBool("jumpON", true);
                        animator.SetBool("runON", false);
                    }
                    if (movPlayer.verticalVelocity < 0)
                    {
                        animator.SetBool("fallON", true);
                        animator.SetBool("runON", false);
                    }
                }


            }



        }
        else
        {
            animator.SetBool("pullON", true);
        }      
    }
}
