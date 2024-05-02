using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class HeatEffect : MonoBehaviour
{
    private float heatLevel = 0f;
    private float maxHeat = 1f;
    private bool isHot = true;

    public Slider heatBar;
    public static event Action tooHot;
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    private void Update()
    {
        if (isHot)
            RunHeatEffect();
    }


    public void StartHeatEffect()
    {
        heatLevel = 0.05f;
        heatBar.value = heatLevel;
        isHot = true;
        heatBar.gameObject.SetActive(true);
    }

    public void RunHeatEffect()
    {
        if (heatLevel < maxHeat)
        {
            heatLevel += 0.01f * Time.deltaTime;
        }
        else
        {
            heatLevel = maxHeat;
            tooHot?.Invoke();
        }
        heatBar.value = heatLevel;

    }
    public void StopHeatEffect()
    {
        StartCoroutine(lowerHeatLevel());
    }

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
