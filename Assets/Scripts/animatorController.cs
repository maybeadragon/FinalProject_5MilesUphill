using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    

   // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //increase performance
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        
    }

   // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool("isJumping");
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        float walkingSpeed = 10.0f;
        float runningSpeed = 40.0f;
        float targetSpeed = 0.0f;
        float maxSpeed = 40.0f;

        //if player press W key
        if (forwardPressed)
        {
            if (runPressed)
            {
                targetSpeed = runningSpeed;
                animator.SetBool(isRunningHash, true);
            }

            else
            {
                targetSpeed = walkingSpeed;
                animator.SetBool(isRunningHash, false);
            }

            animator.SetBool(isWalkingHash, true);
        }



        else
        {
            targetSpeed = 0.0f;
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isRunningHash, false);
        }

        animator.SetFloat("Velocity", targetSpeed / maxSpeed);


        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }


    }

}



