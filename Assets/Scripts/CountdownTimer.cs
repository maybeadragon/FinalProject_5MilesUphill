using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float timeAllowed = 900f; // 900 sec = 15 minutes
    static TextMeshProUGUI timerText; 
    public static Boolean isEnabled;
    private static Boolean wasStarted;
    private static float timeWhenPaused;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.fontSize = 24f;
        EnableTimer();
        HeatEffect.tooHot += DisableTimer;
        TornadoEffect.caught += DisableTimer;
        ColdEffect.tooCold += DisableTimer;
        PauseGame.Quit += QuitTimer;

    }
    private void OnDisable()
    {
        HeatEffect.tooHot -= DisableTimer;
        TornadoEffect.caught -= DisableTimer;
        ColdEffect.tooCold -= DisableTimer;
        PauseGame.Quit -= QuitTimer;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeAllowed > 0 && isEnabled)
        {
            timeAllowed -= Time.deltaTime;

        }
        if (timeAllowed <= 0 && isEnabled)
        {
            timeAllowed = 0;
            SceneManager.LoadSceneAsync("FailScreen");
        }

        float minutes = Mathf.FloorToInt(timeAllowed / 60f);
        float seconds = Mathf.FloorToInt(timeAllowed % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    // TO DO: add enable/disable timer

    public static void EnableTimer()
    {
        isEnabled = true;
        if (wasStarted)
        {
            timeAllowed = timeWhenPaused;
        }
        wasStarted = false;

    }

    public static void DisableTimer()
    {
        isEnabled = false;
        wasStarted = true;
        timeWhenPaused = timeAllowed;
    }

    public static void QuitTimer()
    {
        isEnabled = false;
        wasStarted = false;
        timeAllowed = 900f;
    }
}
