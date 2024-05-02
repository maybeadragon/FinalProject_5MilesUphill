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

    // moves tornado
    void Update()
    {
        TransformTornado();
    }

    // for each point in the tornado's path, if the tornado is close to it
    // it moves on to the next one
    // otherwise, it moves towards the current pointt
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

    }
}
