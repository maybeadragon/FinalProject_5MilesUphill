using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RainEffect : MonoBehaviour
{
    private float rainLevel = 0f;
    private float maxRain = 1f;
    private bool isRaining;

    public ParticleSystem rainEffect;
    public Slider rainBar;
    // Start is called before the first frame update
    void Start()
    {
        StartRaining();
        SanctuaryZone.enterSanctuary += StopRaining;
        SanctuaryZone.exitSanctuary += StartRaining;

    }
    private void OnDisable()
    {
        SanctuaryZone.enterSanctuary -= StopRaining;
        SanctuaryZone.exitSanctuary -= StartRaining;
    }


    // Update is called once per frame
    void Update()
    {
        if (isRaining)
            Raining();

    }

    public void StartRaining()
    {
        if (rainBar == null)
        {
            rainBar = GetComponent<Slider>();
        }
        if (rainEffect == null)
        {
            rainEffect = GetComponent<ParticleSystem>();
        }
        if (UnityEngine.Random.Range(0f, 1f) <= 0.2f)
        {
            rainEffect.Play();
            rainLevel = 0.05f;
            rainBar.value = rainLevel;
            isRaining = true;
            rainBar.gameObject.SetActive(true);
        }
        else
        {
            StopRaining();
        }

        
        
    }

    public void StopRaining()
    {
        rainEffect.Stop();
        StartCoroutine(lowerRainLevel());
        
    }

    public void Raining()
    {
        if (rainLevel < maxRain)
        {
            rainLevel += 0.01f * Time.deltaTime;
        }
        else
        {
            rainLevel = maxRain;
        }
        rainBar.value = rainLevel;

    }
    public IEnumerator lowerRainLevel()
    {
        
        while (rainLevel > 0)
        {
            rainLevel -= 0.01f;
            rainBar.value = rainLevel;
        }
        yield return new WaitForSeconds(3f);
        rainLevel = 0f;
        rainBar.value = rainLevel;
        isRaining = false;
        rainBar.gameObject.SetActive(false);
    }


}
