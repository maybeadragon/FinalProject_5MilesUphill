using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class HeatEffect : MonoBehaviour
{
    public static float heatIncrease = 0.01f;


    private float heatLevel = 0f;
    private float maxHeat = 1f;
    private bool isHot = true;

    public Slider heatBar;
    public static event Action tooHot;
    
    // Starts heat effect
    void Start()
    {
        SanctuaryZone.enterSanctuary += StopHeatEffect;
        SanctuaryZone.exitSanctuary += StartHeatEffect;
        PickUpItems.collectedShelterItem += StopHeatEffect;
        if (isHot)
            StartHeatEffect();
    }

    private void OnDisable()
    {
        SanctuaryZone.enterSanctuary -= StopHeatEffect;
        SanctuaryZone.exitSanctuary -= StartHeatEffect;
        PickUpItems.collectedShelterItem -= StopHeatEffect;
    }

    // Runs heat effect if isHot is true
    private void Update()
    {
        if (isHot)
            RunHeatEffect();
    }

    // starts heat effect
    public void StartHeatEffect()
    {
        heatLevel = 0.05f;
        heatBar.value = heatLevel;
        isHot = true;
        heatBar.gameObject.SetActive(true);
    }

    // runs the heat effect until it gets too hot,
    // then triggers event
    public void RunHeatEffect()
    {
        if (heatLevel < maxHeat)
        {
            heatLevel += heatIncrease * Time.deltaTime;
        }
        else
        {
            heatLevel = maxHeat;
            tooHot?.Invoke();
        }
        heatBar.value = heatLevel;

    }

    // stops the heat effect
    public void StopHeatEffect()
    {
        StartCoroutine(lowerHeatLevel());
    }

    // visibly decreases the heat level through coroutine
    private IEnumerator lowerHeatLevel ()
    {
        while (heatLevel > 0)
        {
            heatLevel -= 0.05f;
            heatBar.value = heatLevel;
        }
        yield return new WaitForSeconds(2f);
        heatLevel = 0f;
        heatBar.value = heatLevel;
        isHot = false;
        heatBar.gameObject.SetActive(false);
    }

}
