using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLocationRandomizer : MonoBehaviour
{
    private int randBoxIndex;
    private GameObject spawnBox;
    private float xRandPosition;
    private float zRandPosition;
    private float spawnBoxXScale;
    private float spawnBoxZScale;

    public List<GameObject> spawnBoxes;
    public GameObject randomizedItem;
    // Start is called before the first frame update
    private void Awake()
    {
        randBoxIndex = UnityEngine.Random.Range(0, spawnBoxes.Count);
        spawnBox = spawnBoxes[randBoxIndex];
        spawnBoxXScale = spawnBox.transform.localScale.x / 2f;
        spawnBoxZScale = spawnBox.transform.localScale.z / 2f;
        xRandPosition = UnityEngine.Random.Range(-spawnBoxXScale, spawnBoxXScale);
        zRandPosition = UnityEngine.Random.Range(-spawnBoxZScale, spawnBoxZScale);
    }
    void Start()
    {
        randomizedItem.transform.position = spawnBox.transform.position + new Vector3(xRandPosition, 0f, zRandPosition);
    }

    
}
