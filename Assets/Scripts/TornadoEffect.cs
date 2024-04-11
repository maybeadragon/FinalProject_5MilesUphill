using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TornadoEffect : MonoBehaviour
{
    private float pullLevel = 0f;
    private float maxPull = 100f;

    public Slider tornadoBar;
    public GameObject player;
    public GameObject tornado;

    // Start is called before the first frame update
    void Start()
    {
        tornadoBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
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
