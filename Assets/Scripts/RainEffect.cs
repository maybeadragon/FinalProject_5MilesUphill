using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using System;

public class RainEffect : MonoBehaviour
{
    private float rainLevel = 0f;
    private float maxRain = 1f;
    private bool isRaining;

    public ParticleSystem rainEffect;
    public Slider rainBar;
    public static event Action tooRainy;
    public static event Action justRain;

    // Start rain effect
    // has random chance of occuring on level
    void Start()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= 0.2f)
        {
            StartRaining();
        }
        else
        {
            StopRaining();
        }
        justRain?.Invoke();
        SanctuaryZone.enterSanctuary += StopRaining;
        SanctuaryZone.exitSanctuary += StartRaining;
        PickUpItems.collectedShelterItem += StopRaining;
    }
        


    private void OnDisable()
    {
        SanctuaryZone.enterSanctuary -= StopRaining;
        SanctuaryZone.exitSanctuary -= StartRaining;
        PickUpItems.collectedShelterItem -= StopRaining;
    }


    // Keeps raining so long as isRaining is true
    void Update()
    {
        if (isRaining)
            Raining();

    }

    // starts rain effect
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
        
        rainEffect.Play();
        rainLevel = 0.05f;
        rainBar.value = rainLevel;
        isRaining = true;
        rainBar.gameObject.SetActive(true);
        
    }

    // stops rain effect
    public void StopRaining()
    {
        rainEffect.Stop();
        rainLevel = 0f;
        rainBar.value = rainLevel;
        isRaining = false;
        rainBar.gameObject.SetActive(false);
    }

    // runs rain effect
    // if the rain level gets too high, will call event
    // event starts cold effect
    public void Raining()
    {
        if (rainLevel < maxRain)
        {
            rainLevel += 0.01f * Time.deltaTime;
        }
        else
        {
            rainLevel = maxRain;
            tooRainy?.Invoke();
        }
        rainBar.value = rainLevel;

    }

    // visibly reduces rain level through coroutine
    public IEnumerator lowerRainLevel()
    {
        
        while (rainLevel > 0)
        {
            rainLevel -= 0.01f;
            rainBar.value = rainLevel;
        }
        yield return new WaitForSeconds(2f);
        rainLevel = 0f;
        rainBar.value = rainLevel;
        isRaining = false;
        rainBar.gameObject.SetActive(false);
    }


}
