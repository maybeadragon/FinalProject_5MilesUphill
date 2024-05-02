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
    
    // when player collides with exit, checks for keys on dark forest, exits for others
    private void OnCollisionEnter(Collision other)
    {
        Collider collider = other.collider;
        if (collider.CompareTag("Player"))
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



}
