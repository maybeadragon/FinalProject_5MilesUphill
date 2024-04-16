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
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //if player press W key
        if (!isWalking && forwardPressed)
        {
            //then set isWalking boolean to true
            animator.SetBool(isWalkingHash, true);
        }

        //if player doesnt press W key
        if (isWalking && !forwardPressed)
        {
            //set isWalking boolean to false
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            //then set isWalking boolean to true
            animator.SetBool(isRunningHash, true);
        }

        //if player doesnt press W key nor LShift
        if (isRunning && (!forwardPressed || !runPressed))
        {
            //set isWalking boolean to false
            animator.SetBool(isRunningHash, false);
        }


    }
}