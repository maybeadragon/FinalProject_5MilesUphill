using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class deathwall : MonoBehaviour
{
      public static event Action fell;
      
      public GameObject stalkertp;
      void OnTriggerEnter(Collider other)
      {
          
            if (other.CompareTag("Player"))
            {
                  fell?.Invoke();
            }
            else if (other.CompareTag("boulder"))
            {
                  Destroy(other);
            }
            else if (other.CompareTag("enemy"))
            {
                  Destroy(other.gameObject);
            }
            else if (other.CompareTag("stalker"))
            {
                other.transform.position = stalkertp.transform.position;
            }
            
     
      }
      
}
