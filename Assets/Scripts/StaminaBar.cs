using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private float stamina;
    private float maxStamina = 1f;
    private float staminaDecrease = -.2f;
    private float staminaIncrease = .3f;
    public static bool canRun;

    public Slider staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
        canRun = (stamina >= 0f);

        PickUpItems.collectedStaminaItem += StaminaBoost;
    }
    private void OnDisable()
    {
        PickUpItems.collectedStaminaItem -= StaminaBoost;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            staminaBar.gameObject.SetActive(true);
            stamina += staminaDecrease * Time.deltaTime;
            staminaBar.value = stamina;
            canRun = (stamina >= 0f);
        }
        else
        {
            if (stamina < maxStamina)
            {
                stamina += staminaIncrease * Time.deltaTime;
                staminaBar.value = stamina;
                Input.GetKeyDown(KeyCode.LeftShift);
                canRun = false;

            }
            else
            {
                stamina = maxStamina;
                canRun = true;
                staminaBar.gameObject.SetActive(false);
            }
        }
    }

    private void StaminaBoost()
    {
        if (UnityEngine.Random.Range(1, 3) == 1)
        {
            staminaDecrease += 0.05f;
        }
        else
        {
            staminaIncrease += 0.05f;
        }

    }
}
