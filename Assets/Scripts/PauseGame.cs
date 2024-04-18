using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;
    public static event Action Quit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                PlayAction();
            else
                PauseAction();
        }
    }

    public void PauseAction() 
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void PlayAction()
    {
        Debug.Log("play");
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void QuitAction()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        Quit?.Invoke();
    }
}
