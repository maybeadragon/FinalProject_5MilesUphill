using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveTornado : MonoBehaviour
{
    private int i = 0;
    private GameObject tornadoPath;

    public List<GameObject> points = new List<GameObject>();
    public GameObject tornado;


    // Start is called before the first frame update
    void Start()
    {
        tornadoPath = points[i];
    }

    // Update is called once per frame
    void Update()
    {
        TransformTornado();
    }


    private void TransformTornado()
    {

        if (i < points.Count - 1)
        {
            if (Vector3.Distance(tornadoPath.transform.position, tornado.transform.position) < 1f)
            {
                i++;
                tornadoPath = points[i];
            }

        }
        else
        {
            if (Vector3.Distance(tornadoPath.transform.position, tornado.transform.position) < 1f)
            {
                i = 0;
                tornadoPath = points[i];
            }
        }
        tornado.transform.position = Vector3.Slerp(tornado.transform.position, tornadoPath.transform.position, 1f * Time.deltaTime);



        /*
         * if (tornado.transform.position.x > points[i].transform.position.x + 1f && tornado.transform.position.x < points[i].transform.position.x - 1f)
        {
            
            
        }
        else if (tornado.transform.position.z > points[i].transform.position.z + 1f && tornado.transform.position.z < points[i].transform.position.z - 1f)
        {
            tornado.transform.localPosition += new Vector3(0f, 0f, 1f * Time.deltaTime);
        }
        else
        {
           
        }
        if (tornado.transform.position.z < points[i].transform.position.z + 1f && tornado.transform.position.z > points[i].transform.position.z - 1f)
        {
            
        }
        else
        {
            tornado.transform.localPosition += new Vector3(0f, 0f, points[i].transform.position.z * Time.deltaTime);
        }*/
    }
}
