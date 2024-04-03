using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    private bool hasKeyItem = false;

    private void OnTriggerEnter(Collider item)
    {
        if (item.CompareTag("KeyItem"))
        {
            hasKeyItem = true;

            OnCollectKeyItem();

        }

    }

    private void OnCollectKeyItem()
    {
        Debug.Log("Player picked up an item");
        /*TBC, Write what happens after item is collected
         * Door unlock
         */
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
