using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Item collection script
 */

public class PlayerController : MonoBehaviour
{
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

        //To extend, copy above code and use different tags (Make sure to tag the item object)

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
    }
}
