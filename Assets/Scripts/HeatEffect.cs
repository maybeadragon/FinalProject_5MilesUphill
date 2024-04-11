using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatEffect : MonoBehaviour
{
    private float heatLevel = 0f;
    private float maxHeat = 100f;

    public Slider heatBar;
    
    // Start is called before the first frame update
    void Start()
    {
        heatBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            heatLevel = 0.05f;
            heatBar.value = heatLevel;
            heatBar.gameObject.SetActive(true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (heatLevel < maxHeat)
            {
                heatLevel += 0.01f * Time.deltaTime;
            }
            else
            {
                heatLevel = maxHeat;
                GameManager.LoadScene("FailScreen");
            }
        }
        heatBar.value = heatLevel;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            heatLevel = 0f;
            heatBar.value = heatLevel;
            heatBar.gameObject.SetActive(false);
        }
    }


}
