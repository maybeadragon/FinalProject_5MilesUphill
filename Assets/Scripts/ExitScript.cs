using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public GameObject exit;
    public GameObject player;
    private bool hasAllKeys;

    public static event Action exitLevel;
    public static event Action sendNotification;
    

    private void OnCollisionEnter()
    {
        if (SceneManager.GetActiveScene().name == "darkforest")
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
        else
        {
            exitLevel?.Invoke();
        }

    }



}
