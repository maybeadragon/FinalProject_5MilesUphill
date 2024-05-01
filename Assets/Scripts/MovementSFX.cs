using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSFX : MonoBehaviour
{
    public AudioSource footstep, jump;
    private bool onFloor;

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            footstep.enabled = true;
            footstep.volume = Random.Range(0.5f, 0.7f);
            footstep.pitch = Random.Range(0.65f, 1.2f);
        }
        else
        {
            footstep.enabled = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            footstep.enabled = false;
            jump.enabled = true;
        }
    }
}
