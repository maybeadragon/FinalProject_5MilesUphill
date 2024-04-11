using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static int levelsCompleted = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().Equals("StartScreen") || 
            SceneManager.GetActiveScene().Equals("FailScreen") || 
            SceneManager.GetActiveScene().Equals("SuccessScreen")) 
            && levelsCompleted > 0) 
        {
            levelsCompleted = 0;
        }
    }
    public static void LoadScene()
    {
        if (levelsCompleted < 5)
        {
            int randIndex = Random.Range(1, 2);
            SceneManager.LoadScene(randIndex);
            levelsCompleted++;
        }
        else if (CountdownTimer.timeAllowed > 0f)
        {
            SceneManager.LoadScene("SuccessScreen");
        }
        else
        {
            SceneManager.LoadScene("FailScreen");
        }

    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        if (index != 0)
        {
            levelsCompleted++;
        }
    }
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if (sceneName != "StartScreen")
        {
            levelsCompleted++;
        }
    }
}
