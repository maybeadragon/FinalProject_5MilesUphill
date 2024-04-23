using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderspawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public int count = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spherePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (count > 2000)
        {
            count = 0;
            Instantiate(spherePrefab, transform.position, Quaternion.identity);
        }
    }
}
