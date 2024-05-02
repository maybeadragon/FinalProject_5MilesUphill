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

    // Update is called once per frame
    void Update()
    {
        hasAllKeys = PickUpItems.hasAllKeys;

        if (Vector3.Distance(player.transform.position, exit.transform.position) < 2f && hasAllKeys)
        {

            exitLevel?.Invoke();
            
        }
        else if (Vector3.Distance(player.transform.position, exit.transform.position) < 2f)
        {
            sendNotification?.Invoke();
        }
    }



}
