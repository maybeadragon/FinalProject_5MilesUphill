using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public GameObject exit;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < (exit.transform.position.x + 1f) && player.transform.position.x > (exit.transform.position.x - 1f))
        {
            if (player.transform.position.z < (exit.transform.position.z + 1f) && player.transform.position.z > (exit.transform.position.z - 1f))
            {
                GameManager.LoadScene();

            }
        }
    }


}
