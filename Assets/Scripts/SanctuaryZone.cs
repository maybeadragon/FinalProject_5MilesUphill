using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SanctuaryZone : MonoBehaviour
{
    public static event Action enterSanctuary;

    public static event Action exitSanctuary;  

    // when trigger zone is entered, sends out event notice (stop effect)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name + " entered the sanctuary");
            enterSanctuary?.Invoke();
        }
    }

    // when trigger zone is exited, sends out another event notice (resume effect)
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name + " left the sanctuary");
            exitSanctuary?.Invoke();
        }
    }
}
