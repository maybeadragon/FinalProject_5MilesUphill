using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    string savedLevel;
    static int levelsCompleted = 0;

    public Animator sceneAnimation;

    // Start is called before the first frame update
    
    void Start()
    {
        HeatEffect.tooHot += Fail;
        TornadoEffect.caught += Fail;
        ColdEffect.tooCold += Fail;
        ExitScript.exitLevel += LoadScene;
        PauseGame.Quit += RestartGame;
        deathwall.fell += Fail;
        boulderstuff.crushed += Fail;
    }

    private void OnDisable()
    {
        HeatEffect.tooHot -= Fail;
        TornadoEffect.caught -= Fail;
        ColdEffect.tooCold -= Fail;
        ExitScript.exitLevel -= LoadScene;
        PauseGame.Quit -= RestartGame;
        deathwall.fell -= Fail;
        boulderstuff.crushed -= Fail;
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

        
    public void LoadScene()
        {
        
        if (levelsCompleted <= 5)
        {
            int randIndex = UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings - 2);
            if (levelsCompleted == 0)
            {
                Debug.Log("start");
                StartCoroutine(PlayOpeningSequence());
            }
            else
            {
                sceneAnimation.SetTrigger("Fade_Out");
                AsyncOperation nextScene = SceneManager.LoadSceneAsync(randIndex);
                savedLevel = SceneManager.GetSceneByBuildIndex(randIndex).name;
                levelsCompleted++;
            }
            
        }
        else
        {
            SceneManager.LoadSceneAsync("SuccessScreen");
            AsyncOperation nextScene = SceneManager.LoadSceneAsync("SuccessScreen");

            if (nextScene.progress <= 0.9)
            {
                sceneAnimation.SetTrigger("Fade_Out");
            }
            levelsCompleted = 0;
            CountdownTimer.timeAllowed = 900f;
        }
        }

    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(index);
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }
        
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(sceneName);
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }   
        
    }

    public void Fail()
    {
        LoadScene("FailScreen");
    }

    public void Succeed()
    {
        LoadScene("SuccessScreen");
    }


    public void PauseLevel()
    {
        Debug.Log("Loading pause screen");
        LoadScene("PauseScreen");
    }

    public void PlayLevel()
    {
        Debug.Log("returning to last level");
        SceneManager.LoadSceneAsync("ExitTesting");
        AsyncOperation nextScene = SceneManager.LoadSceneAsync("ExitTesting");
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("StartScreen");
        AsyncOperation nextScene = SceneManager.LoadSceneAsync("StartScreen");
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }
    }

    private IEnumerator PlayOpeningSequence()
    {
        if (levelsCompleted == 0)
            sceneAnimation.Play("Opening_Sequence");
        yield return new WaitForSeconds(17f);
        levelsCompleted++;
        LoadScene();
        Debug.Log("end");
    }


    private void OnTriggerEnter(Collider other)
    {
        PauseLevel();
    }

}
