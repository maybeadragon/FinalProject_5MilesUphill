using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
    GameObject[] walls;
    int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        walls = new GameObject[20];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    index++;
                    walls[index] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    walls[index].transform.localScale = new Vector3(2f, 2f, 2f);
                    walls[index].transform.position = new Vector3(3f + index, 0f, 0f);
                    break;
                case 2:
                    index++; 
                    walls[index] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    walls[index].transform.localScale = new Vector3(2f, 5f, 5f);
                    walls[index].transform.position = new Vector3(-4f - index, 0f, 0f);
                    break;
                default:
                    index++;
                    walls[index] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.W) && index >= 0)
        {
            Destroy(walls[index]);
            index--;
        }
    }
}
