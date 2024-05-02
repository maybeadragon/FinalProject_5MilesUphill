using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/*
 * Item collection script
 */

public class PickUpItems : MonoBehaviour
{
    public static bool hasAllKeys = false;
    public static int keyCount = 0;

    public static event Action collectedKeyItem;
    public static event Action collectedTimeItem;
    public static event Action collectedStaminaItem;
    public static event Action collectedSpeedItem;
    public static event Action collectedShelterItem;

    private void OnCollisionEnter(Collision collided)
    {
        Collider item = collided.collider;

        // key collection
        if (item.gameObject.CompareTag("KeyItem") && SceneManager.GetActiveScene().name != "darkforest")
        {
            hasAllKeys = true;
            item.gameObject.SetActive(false);
            collectedKeyItem?.Invoke();
        }
        else if (item.gameObject.CompareTag("KeyItem"))
        {
            keyCount++;
            if (keyCount == 5)
            {
                hasAllKeys = true;
            }
            item.gameObject.SetActive(false);
            collectedKeyItem?.Invoke();

        }

        // time item collection
        if (item.gameObject.CompareTag("TimeItem"))
        {
            item.gameObject.SetActive(false);
            collectedTimeItem?.Invoke();
        }

        // stamina item collection
        if (item.gameObject.CompareTag("StaminaItem"))
        {
            item.gameObject.SetActive(false);
            collectedStaminaItem?.Invoke();
        }

        // speed item collection
        if (item.gameObject.CompareTag("SpeedItem"))
        {
            item.gameObject.SetActive(false);
            collectedSpeedItem?.Invoke();
        }

        // shelter item collection
        if (item.gameObject.CompareTag("ShelterItem"))
        {
            item.gameObject.SetActive(false);
            collectedShelterItem?.Invoke();
        }
        //To extend, copy above code and use different tags (Make sure to tag the item object)

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
