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
    public static int levelsCompleted = 0;

    public Animator sceneAnimation;

    public static event Action end;

    // Start is called before the first frame update
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HeatEffect.tooHot += Fail;
        TornadoEffect.caught += Fail;
        ColdEffect.tooCold += Fail;
        ExitScript.exitLevel += LoadScene;
        PauseGame.Quit += RestartGame;
        deathwall.fell += Fail;
        boulderstuff.crushed += Fail;
        StalkerPursuit.grounded += Fail;
        BasicPursuit.agentGameOver += Fail;
        CountdownTimer.outOfTime += Fail;
        StartGame.startgame += LoadScene;
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
        StalkerPursuit.grounded -= Fail;
        BasicPursuit.agentGameOver -= Fail;
        CountdownTimer.outOfTime -= Fail;
        StartGame.startgame -= LoadScene;
    }

    // ensures levelsCompleted is reset to zero
    void Update()
    {
        if ((SceneManager.GetActiveScene().name.Equals("StartScreen") || 
            SceneManager.GetActiveScene().name.Equals("FailScreen") || 
            SceneManager.GetActiveScene().name.Equals("SuccessScreen")) 
            && levelsCompleted > 0) 
        {
            levelsCompleted = 0;
        }
    }

     // loads random scene, and when 5 random scenes are completed, goes to success screen   
    public void LoadScene()
        {
        
        if (levelsCompleted <= 5)
        {
            int randIndex = UnityEngine.Random.Range(1, 4);
            if (levelsCompleted == 0)
            {
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
            end?.Invoke();
        }
        }

    // load scene of specific index
    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(index);
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }
        
    }

    // load scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

        AsyncOperation nextScene = SceneManager.LoadSceneAsync(sceneName);
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }   
        
    }

    // for events, directly calls fail
    public void Fail()
    {
        LoadScene("FailScreen");
        end?.Invoke();
    }

    // for events, directly calls success
    public void Succeed()
    {
        LoadScene("SuccessScreen");
        end?.Invoke();
    }

    // for events, restarts the game
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("StartScreen");
        AsyncOperation nextScene = SceneManager.LoadSceneAsync("StartScreen");
        if (nextScene.progress <= 0.9)
        {
            sceneAnimation.SetTrigger("Fade_Out");
        }
        end?.Invoke();
    }

    // coroutine, plays the opening sequence only when starting
    private IEnumerator PlayOpeningSequence()
    {
        if (levelsCompleted == 0)
            sceneAnimation.Play("Opening_Sequence");
        yield return new WaitForSeconds(17f);
        levelsCompleted++;
        LoadScene();
    }


}
