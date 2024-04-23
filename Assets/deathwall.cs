using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathwall : MonoBehaviour
{
     
     
   void OnTriggerEnter(Collider other)
    {
          Destroy(other);
     
    }
}
