using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainEffect : MonoBehaviour
{
    private float rainLevel = 0f;
    private float maxRain = 100f;
    public ParticleSystem rainEffect;
    public Slider rainBar;
    // Start is called before the first frame update
    void Start()
    {
        rainBar.gameObject.SetActive(false); 
        rainEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rainEffect.Play();
            rainLevel = 0.05f;
            rainBar.value = rainLevel;
            rainBar.gameObject.SetActive(true);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rainLevel < maxRain)
            {
                rainLevel += 0.01f * Time.deltaTime;
            }
            else
            {
                rainLevel = maxRain;
            }
        }
        rainBar.value = rainLevel;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rainEffect.Stop();
            rainLevel = 0f;
            rainBar.value = rainLevel;
            rainBar.gameObject.SetActive(false);
        }
    }
    
}
