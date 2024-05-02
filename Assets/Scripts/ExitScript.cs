using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitScript : MonoBehaviour
{
    public GameObject exit;
    public GameObject player;
    private bool hasAllKeys;

    public static event Action exitLevel;
    public static event Action sendNotification;
    

    private void OnCollisionEnter()
    {
        hasAllKeys = PickUpItems.hasAllKeys;

        if (hasAllKeys)
        {

            exitLevel?.Invoke();

        }
        else
        {
            sendNotification?.Invoke();
        }
    }



}
