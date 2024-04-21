using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player Controller, Item Collection, Basic movement (No animations)
/// </summary>
/// 

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    private bool hasKeyItem = false;
    public float jump = 10f;
    private bool onFloor;

    private void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.CompareTag("KeyItem"))
        {
            hasKeyItem = true;
            item.gameObject.SetActive(false);
            OnCollectKeyItem();

        }

        if (item.gameObject.CompareTag("Finish"))
        {
            if (hasKeyItem) {
                Debug.Log("Level Finished");
            }
            else {
                Debug.Log("Player has not obtained KeyItem");
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //Make sure floor is tagged "Floor"
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    private void OnCollectKeyItem()
    {
        Debug.Log("Player picked up an item");
        
    }



    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * verticalInput + right * horizontalInput;

        transform.Translate(move * speed * Time.deltaTime, Space.World);

        //Jump, by default is spacebar
        /*
        To adjust jump strength, change the 'jump' variable or the 'Mass' of the player object in Rigidbody
        jump = 10, Mass = 2 seems pretty good to me
        */
        
        if (Input.GetButtonDown("Jump") && onFloor)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            onFloor = false;
        }
    }
}
