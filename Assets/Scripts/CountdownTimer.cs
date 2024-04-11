using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private float timeAllowed;
    public TextMeshProUGUI timerText;
    public Boolean isEnabled;
    private Boolean wasStarted;
    private float timeWhenPaused;
    // Start is called before the first frame update
    void Start()
    {
        timeAllowed = 10f; // 900 sec = 15 minutes, could change depending on difficulty
        EnableTimer();
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
            SceneManager.LoadScene("FailScreen");
        }

        float minutes = Mathf.FloorToInt(timeAllowed / 60f);
        float seconds = Mathf.FloorToInt(timeAllowed % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (Input.GetKeyDown(KeyCode.Escape) && isEnabled)
        {
            DisableTimer();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnableTimer();
        }

    }

    // TO DO: add enable/disable timer

    public void EnableTimer()
    {
        isEnabled = true;
        if (wasStarted)
        {
            timeAllowed = timeWhenPaused;
        }
        wasStarted = false;

    }

    public void DisableTimer()
    {
        isEnabled = false;
        wasStarted = true;
        timeWhenPaused = timeAllowed;
    }
}
