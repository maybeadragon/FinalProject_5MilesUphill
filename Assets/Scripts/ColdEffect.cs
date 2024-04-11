using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdEffect : MonoBehaviour
{
    private float coldLevel = 0f;
    private float maxCold = 100f;

    public Slider coldBar;

    // Start is called before the first frame update
    void Start()
    {
        coldBar.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coldLevel = 0.05f;
            coldBar.value = coldLevel;
            coldBar.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coldLevel < maxCold)
            {
                coldLevel += 0.01f * Time.deltaTime;
            }
            else
            {
                coldLevel = maxCold;
                GameManager.LoadScene("FailScreen");
            }
        }
        coldBar.value = coldLevel;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coldLevel = 0f;
            coldBar.value = coldLevel;
            coldBar.gameObject.SetActive(false);
        }
    }

}
