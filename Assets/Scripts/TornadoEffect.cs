using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TornadoEffect : MonoBehaviour
{
    private float pullLevel = 0f;
    private float maxPull = 1f;

    public Slider tornadoBar;
    public GameObject player;
    public GameObject tornado;
    public static event Action caught;

    // Start is called before the first frame update
    void Start()
    { 
        tornadoBar.gameObject.SetActive(false);
        float randFloat = UnityEngine.Random.Range(1f, 1f);
        
    }

    // If the player is close to the tornado, the player will be pulled towards it
    // if player doesn't escape fast enough, triggers event (fail)
    void Update()
    {
        if (player.transform.position.x < tornado.transform.position.x + 10 && player.transform.position.x > tornado.transform.position.x - 10)
        {
            if(player.transform.position.z < tornado.transform.position.z + 10 && player.transform.position.z > tornado.transform.position.z - 10)
            {
                tornadoBar.gameObject.SetActive(true);
                if (pullLevel < maxPull)
                {
                    pullLevel += 1f * Time.deltaTime;
                    player.transform.localPosition += new Vector3(tornado.transform.position.x / 2 * Time.deltaTime, 0f, tornado.transform.position.z / 2 * Time.deltaTime);
                }
                else
                {
                    pullLevel = maxPull;
                    player.transform.localPosition += new Vector3(0f, 5f * Time.deltaTime, 0f);
                    caught?.Invoke();
                }
                tornadoBar.value = pullLevel;
            }
        }
        else
        {
            pullLevel = 0f;
            tornadoBar.value = pullLevel;
            tornadoBar.gameObject.SetActive(false);
        }
    }
    
}
