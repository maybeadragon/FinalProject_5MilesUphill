using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class boulderstuff : MonoBehaviour
{
    private int suicidecount = 0;
    public static event Action crushed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        suicidecount += 1;
        if (suicidecount > 10000)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            crushed?.Invoke();
        }
    }
    // Update is called once per frame
    
}
