using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitScript : MonoBehaviour
{
    public GameObject exit;
    public GameObject player;

    public static event Action exitLevel;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < (exit.transform.position.x + 2f) && player.transform.position.x > (exit.transform.position.x - 2f))
        {
            if (player.transform.position.z < (exit.transform.position.z + 2f) && player.transform.position.z > (exit.transform.position.z - 2f))
            {
                exitLevel?.Invoke();

            }
        }
    }



}
