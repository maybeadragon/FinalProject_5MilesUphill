using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdEffect : MonoBehaviour
{
    private float coldLevel = 0f;
    private float maxCold = 1f;
    private bool isCold = true;

    public Slider coldBar;
    public static event Action tooCold;

    // Start is called before the first frame update
    void Start()
    {
        if(isCold)
            StartColdEffect();
        SanctuaryZone.enterSanctuary += StopColdEffect;
        SanctuaryZone.exitSanctuary += StartColdEffect;
        RainEffect.justRain += StopColdEffect;
        RainEffect.tooRainy += StartColdEffect;
        PickUpItems.collectedShelterItem += StopColdEffect;
    }
    private void OnDisable()
    {
        SanctuaryZone.enterSanctuary -= StopColdEffect;
        SanctuaryZone.exitSanctuary -= StartColdEffect;
        RainEffect.justRain -= StopColdEffect;
        RainEffect.tooRainy -= StartColdEffect;
        PickUpItems.collectedShelterItem -= StopColdEffect;
    }

    private void Update()
    {
        if (isCold)
            RunColdEffect();
    }

    public void StartColdEffect()
    {
        coldLevel = 0.05f;
        coldBar.value = coldLevel;
        isCold = true;
        coldBar.gameObject.SetActive(true);
    }
    public void StopColdEffect()
    {
        StartCoroutine(lowerColdLevel());
    }

    public void RunColdEffect()
    {
        if (coldLevel < maxCold)
        {
            coldLevel += 0.01f * Time.deltaTime;
        }
        else
        {
            coldLevel = maxCold;
            tooCold?.Invoke();
        }
        coldBar.value = coldLevel;
    }


    private IEnumerator lowerColdLevel()
    {
        while (coldLevel > 0)
        {
            coldLevel -= 0.05f;
            coldBar.value = coldLevel;
        }
        yield return new WaitForSeconds(2f);
        coldLevel = 0f;
        coldBar.value = coldLevel;
        isCold = false;
        coldBar.gameObject.SetActive(false);
    }

}
