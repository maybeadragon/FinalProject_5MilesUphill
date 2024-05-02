using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< Updated upstream
=======
using UnityEngine.EventSystems;
using System;
>>>>>>> Stashed changes

public class RainEffect : MonoBehaviour
{
    private float rainLevel = 0f;
    private float maxRain = 1f;
    private bool isRaining;

    public ParticleSystem rainEffect;
    public Slider rainBar;
    public static event Action tooRainy;
    public static event Action justRain;
    // Start is called before the first frame update
    void Start()
    {
        StartRaining();
<<<<<<< Updated upstream

    }
=======
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
>>>>>>> Stashed changes


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
        rainEffect.Play();
        rainLevel = 0.05f;
        rainBar.value = rainLevel;
        isRaining = true;
        rainBar.gameObject.SetActive(true);
    }

    public void StopRaining()
    {
        rainEffect.Stop();
        rainLevel = 0f;
        rainBar.value = rainLevel;
        isRaining = false;
        rainBar.gameObject.SetActive(false);
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
            tooRainy?.Invoke();
        }
        rainBar.value = rainLevel;

    }
<<<<<<< Updated upstream
=======
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

>>>>>>> Stashed changes

}
