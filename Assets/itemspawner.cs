using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itemspawner : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject item7;

    public int itemnum;

    // Start is called before the first frame update
    void Start()
    {
        
        itemnum = Random.Range(1,8);

        if (itemnum == 1)
        {
            Instantiate(item1, transform.position, Quaternion.identity);
        }
        else if (itemnum == 2)
        {
            Instantiate(item2, transform.position, Quaternion.identity);
        }
        else if (itemnum == 3)
        {
            Instantiate(item3, transform.position, Quaternion.identity);
        }
        else if (itemnum == 4)
        {
            Instantiate(item4, transform.position, Quaternion.identity);
        }
        else if (itemnum == 5)
        {
            Instantiate(item5, transform.position, Quaternion.identity);
        }
        else if (itemnum == 6)
        {
            Instantiate(item6, transform.position, Quaternion.identity);
        }
        else if (itemnum == 7)
        {
            Instantiate(item7, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
