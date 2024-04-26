using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestRandomSceneChange : MonoBehaviour
{
    public GameObject prefab;
    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(UnityEngine.Random.Range(0, 3));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    item = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    item.transform.position = new Vector3(1f, 3f, 1f);
                    break;
                case 1:
                    item = GameObject.Instantiate(prefab);
                    item.transform.position = new Vector3(1f, 3f, 1f);
                    break;
                default:
                    Debug.LogError("Something went wrong in TestRandomSceneChange"); break;


            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.Destroy(item);
        }
    }
}
