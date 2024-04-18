using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPlacement : MonoBehaviour
{
    public List<GameObject> keyLocations = new List<GameObject>();
    private List<GameObject> keys = new List<GameObject>();
    public GameObject keyPrefab;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "darkforest")
        {
            for (int i = 0; i < keyLocations.Count; i++)
            { 
                keys.Add(Instantiate(keyPrefab));
                keys[i].transform.position = keyLocations[i].transform.position;
                keyLocations[i].SetActive(false);
                keys[i].SetActive(true);
            }
        }
        else
        {
            int randKeySpot = Random.Range(0, keyLocations.Count);
            for (int i = 0; i < keyLocations.Count; i++)
            {
                if (i == randKeySpot)
                {
                    keys.Add(Instantiate(keyPrefab));
                    keys[i].transform.position = keyLocations[i].transform.position;
                }
                keyLocations[i].SetActive(false);
                keys[i].SetActive(true);

            }
        }
    }
   
}
