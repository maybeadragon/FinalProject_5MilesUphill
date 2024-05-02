using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSFX : MonoBehaviour
{
    public AudioSource footstep, jump;
    private bool onFloor;
    float footstepSpeed = 0.9f;

    void OnCollisionEnter(Collision collision)
    {
        //Make sure floor is tagged "Floor"
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            footstepSpeed = 1.5f; 
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            footstepSpeed = 0.9f; 
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            footstep.enabled = true;
            footstep.volume = Random.Range(0.5f, 0.7f);
            footstep.pitch = footstepSpeed;

        }
        else
        {
            footstep.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            footstep.enabled = false;
            jump.enabled = true;
            StartCoroutine(DisableJump(1f));
        } 
    }

    IEnumerator DisableJump(float x)
    {
        yield return new WaitForSeconds(x);
        jump.enabled = false;
    }

    
}
