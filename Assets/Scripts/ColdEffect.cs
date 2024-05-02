using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdEffect : MonoBehaviour
{
    public static float coldIncrease = 0.01f;

    private float coldLevel = 0f;
    private float maxCold = 1f;
    private bool isCold = true;

    public Slider coldBar;
    public static event Action tooCold;

    // Start cold effect
    void Start()
    {
        if(isCold)
            StartColdEffect();
        SanctuaryZone.enterSanctuary += StopColdEffect;
        //SanctuaryZone.exitSanctuary += StartColdEffect;
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

    // if isCold is true, cold effect continues
    private void Update()
    {
        if (isCold)
            RunColdEffect();
    }

    // starts the cold effect
    public void StartColdEffect()
    {
        coldLevel = 0.05f;
        coldBar.value = coldLevel;
        isCold = true;
        coldBar.gameObject.SetActive(true);
    }

    // stops the cold effect
    public void StopColdEffect()
    {
        StartCoroutine(lowerColdLevel());
    }

    // runs the cold effect, and if it gets too cold, triggers event
    public void RunColdEffect()
    {
        if (coldLevel < maxCold)
        {
            coldLevel += coldIncrease * Time.deltaTime;
        }
        else
        {
            coldLevel = maxCold;
            tooCold?.Invoke();
        }
        coldBar.value = coldLevel;
    }

    // coroutine to have the cold level visibly go down
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
