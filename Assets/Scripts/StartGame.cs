using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StartGame : MonoBehaviour
{

    public static event Action startgame;
    
   public void LoadRandomScreen()
    {
        startgame?.Invoke();
    }

    public void LoadSpecificScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
