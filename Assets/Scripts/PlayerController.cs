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
    }
}
