using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CountdownTimer : MonoBehaviour
{
    private float timeAllowed;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timeAllowed = 240f; // 4 minutes, could change depending on difficulty
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAllowed > 0)
        {
            timeAllowed -= Time.deltaTime;

        }
        else
        {
            timeAllowed = 0;
            // action to quit game/go to fail
        }

        float minutes = Mathf.FloorToInt(timeAllowed / 60f);
        float seconds = Mathf.FloorToInt(timeAllowed % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    // TO DO: add enable/disable timer
}
