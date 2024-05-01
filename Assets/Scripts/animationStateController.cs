using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceerlation = 0.5f;
    int VelocityHash;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //increase performance
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        //get key from player
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKeyDown(KeyCode.LeftShift);


        //if player press W key
        if (forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if(!forwardPressed && velocity > 0.0f)
        {
            velocity = Time.deltaTime * deceerlation;
        }

        if(!forwardPressed && velocity < 0.1f)
        {
            velocity = 0.0f;
        }

        animator.SetFloat(VelocityHash, velocity);
    }
}


