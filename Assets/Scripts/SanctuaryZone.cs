using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SanctuaryZone : MonoBehaviour
{
    public static event Action enterSanctuary;

    public static event Action exitSanctuary;  
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name + " entered the sanctuary");
            enterSanctuary?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name + " left the sanctuary");
            exitSanctuary?.Invoke();
        }
    }
}
