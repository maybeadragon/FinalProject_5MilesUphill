using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotificationController : MonoBehaviour
{


    public Animator notifications;
    public TextMeshProUGUI notificationText;
    public GameObject popUp;



    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
        StartNotification();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNotification()
    {
        StartCoroutine(PlayNotification());

    }


    private IEnumerator PlayNotification()
    {
        Debug.Log("Notify");
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                notificationText.text = "You're in the dark forest. Find five keys to exit. Look out for weird neighbors and items!";
                break;
            case 2:
                notificationText.text = "You're in the desert. Beat the heat by finding shade or drinking water.";
                break;
            case 3:
                notificationText.text = "You're in the plains. Look out for tornados and possibly rain. Be careful not to get too wet! Look for an umbrella to stay dry.";
                break;

            default:
                notificationText.text = "You've reached mile " + GameController.levelsCompleted + " of 5. Keep on going!";
                break;
        }
        popUp.SetActive(true); ;
        yield return new WaitForSeconds(5f);
        notifications.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        popUp.SetActive(false); ;
    }
}
