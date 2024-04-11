using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    
   public void LoadRandomScreen()
    {
        SceneManager.LoadScene(Random.Range(1, 2));
    }

    public void LoadSpecificScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
