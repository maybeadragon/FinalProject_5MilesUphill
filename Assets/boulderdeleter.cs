using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderdeleter : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boulder"))
        {
            Destroy(other.gameObject);
        }
     
    }
    
}
