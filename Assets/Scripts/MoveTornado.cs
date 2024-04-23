using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveTornado : MonoBehaviour
{
    private int pointsReached;

    public GameObject tornado;
    public GameObject pointOne;
    public GameObject pointTwo;
    public GameObject pointThree;
    public GameObject pointFour;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TransformTornado();
    }


    private void TransformTornado()
    {
        
        switch (pointsReached % 4)
        {
            case 0:
                
                if (tornado.transform.position.x < pointOne.transform.position.x + 0.5 && tornado.transform.position.x > pointOne.transform.position.x - 0.5)
                {
                    if (tornado.transform.position.z < pointOne.transform.position.z + 0.5 && tornado.transform.position.z > pointOne.transform.position.z - 0.5)
                    {
                        pointsReached++;
                        break;
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(0f, 0f, pointOne.transform.position.z * Time.deltaTime);
                    }
                }
                else
                {
                    if (tornado.transform.position.z < pointOne.transform.position.z + 0.5 && tornado.transform.position.z > pointOne.transform.position.z - 0.5)
                    {

                        tornado.transform.localPosition += new Vector3(pointOne.transform.position.x * Time.deltaTime, 0f, 0f);
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(pointOne.transform.position.x * Time.deltaTime, 0f, pointOne.transform.position.z * Time.deltaTime);
                    }
                }
                break;

            case 1:
                if (tornado.transform.position.x < pointTwo.transform.position.x + 0.5 && tornado.transform.position.x > pointTwo.transform.position.x - 0.5)
                {
                    if (tornado.transform.position.z < pointTwo.transform.position.z + 0.5 && tornado.transform.position.z > pointTwo.transform.position.z - 0.5)
                    {
                        pointsReached++;
                        break;
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(0f, 0f, pointTwo.transform.position.z * Time.deltaTime);
                    }
                }
                else
                {
                    if (tornado.transform.position.z < pointTwo.transform.position.z + 0.5 && tornado.transform.position.z > pointTwo.transform.position.z - 0.5)
                    {

                        tornado.transform.localPosition += new Vector3(pointTwo.transform.position.x * Time.deltaTime, 0f, 0f);
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(pointTwo.transform.position.x * Time.deltaTime, 0f, pointTwo.transform.position.z * Time.deltaTime);
                    }
                }
                break;

            case 2:
                if (tornado.transform.position.x < pointThree.transform.position.x + 0.5 && tornado.transform.position.x > pointThree.transform.position.x - 0.5)
                {
                    if (tornado.transform.position.z < pointThree.transform.position.z + 0.5 && tornado.transform.position.z > pointThree.transform.position.z - 0.5)
                    {
                        pointsReached++;
                        break;
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(0f, 0f, pointThree.transform.position.z * Time.deltaTime);
                    }
                }
                else
                {
                    if (tornado.transform.position.z < pointThree.transform.position.z + 0.5 && tornado.transform.position.z > pointThree.transform.position.z - 0.5)
                    {

                        tornado.transform.localPosition += new Vector3(pointThree.transform.position.x * Time.deltaTime, 0f, 0f);
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(pointThree.transform.position.x * Time.deltaTime, 0f, pointThree.transform.position.z * Time.deltaTime);
                    }
                }
                break;
            case 3:
                if (tornado.transform.position.x < pointFour.transform.position.x + 0.5 && tornado.transform.position.x > pointFour.transform.position.x - 0.5)
                {
                    if (tornado.transform.position.z < pointFour.transform.position.z + 0.5 && tornado.transform.position.z > pointFour.transform.position.z - 0.5)
                    {
                        pointsReached++;
                        break;
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(0f, 0f, pointFour.transform.position.z * Time.deltaTime);
                    }
                }
                else
                {
                    if (tornado.transform.position.z < pointFour.transform.position.z + 0.5 && tornado.transform.position.z > pointFour.transform.position.z - 0.5)
                    {

                        tornado.transform.localPosition += new Vector3(pointFour.transform.position.x * Time.deltaTime, 0f, 0f);
                    }
                    else
                    {
                        tornado.transform.localPosition += new Vector3(pointFour.transform.position.x * Time.deltaTime, 0f, pointFour.transform.position.z * Time.deltaTime);
                    }
                }
                break;
        }

    }
}
