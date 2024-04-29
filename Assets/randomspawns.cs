using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawns : MonoBehaviour
{
    public GameObject exit;
    public GameObject exitlocation1;
    public GameObject exitlocation2;
    public GameObject exitlocation3;
    public GameObject exitlocation4;
    public GameObject exitlocation5;
    public GameObject spawnlocation1;
    public GameObject spawnlocation2;
    public GameObject spawnlocation3;
    public GameObject spawnlocation4;
    public GameObject spawnlocation5;
    public GameObject Player;
    public int setnum;

    // Start is called before the first frame update
    void Start()
    {
        setnum = Random.Range(1,6);
        if (setnum == 1)
        {
            Instantiate(exit, exitlocation1.transform.position , Quaternion.identity);
            Player.transform.position = spawnlocation1.transform.position;
        }
        else if (setnum == 2)
        {
            Instantiate(exit, exitlocation2.transform.position , Quaternion.identity);
            Player.transform.position = spawnlocation2.transform.position;
        }
        else if (setnum == 3)
        {
            Instantiate(exit, exitlocation3.transform.position , Quaternion.identity);
            Player.transform.position = spawnlocation3.transform.position;
        }
        else if (setnum == 4)
        {
            Instantiate(exit, exitlocation4.transform.position , Quaternion.identity);
            Player.transform.position = spawnlocation4.transform.position;
        }
        else if (setnum == 5)
        {
            Instantiate(exit, exitlocation5.transform.position , Quaternion.identity);
            Player.transform.position = spawnlocation5.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
