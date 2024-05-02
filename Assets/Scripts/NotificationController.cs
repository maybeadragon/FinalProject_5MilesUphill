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
        ExitScript.sendNotification += ExitNotice;
        PickUpItems.collectedKeyItem += KeyNotice;
        PickUpItems.collectedTimeItem += TimeNotice;
        PickUpItems.collectedSpeedItem += SpeedNotice;
        PickUpItems.collectedStaminaItem += StaminaNotice;
        PickUpItems.collectedShelterItem += ShelterNotice;
    }
    private void OnDisable()
    {
        ExitScript.sendNotification -= ExitNotice;
        PickUpItems.collectedKeyItem -= KeyNotice;
        PickUpItems.collectedTimeItem -= TimeNotice;
        PickUpItems.collectedSpeedItem -= SpeedNotice;
        PickUpItems.collectedStaminaItem -= StaminaNotice;
        PickUpItems.collectedShelterItem -= ShelterNotice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNotification()
    {
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
                notificationText.text = "hi"; //"You've reached mile " + GameController.levelsCompleted + " of 5. Keep on going!";
                break;
        }
        StartCoroutine(PlayNotification());

    }

    private void ExitNotice()
    {
        notificationText.text = "You need to find all the keys before you can exit!";
        StartCoroutine(PlayNotification());
    }

    private void KeyNotice()
    {
        notificationText.text = "You found a key!";
        StartCoroutine(PlayNotification());
    }

    private void TimeNotice()
    {
        notificationText.text = "You found a time boost!";
        StartCoroutine(PlayNotification());
    }

    private void StaminaNotice()
    {
        notificationText.text = "You found a stamina boost!";
        StartCoroutine(PlayNotification());
    }

    private void SpeedNotice()
    {
        notificationText.text = "You found a speed boost!";
        StartCoroutine(PlayNotification());
    }

    private void ShelterNotice()
    {
        notificationText.text = "You found something to protect you from the weather. Good job!";
        StartCoroutine(PlayNotification());
    }


    private IEnumerator PlayNotification()
    {
        popUp.SetActive(true); ;
        yield return new WaitForSeconds(5f);
        notifications.SetTrigger("Close");
        yield return new WaitForSeconds(.5f);
        popUp.SetActive(false); ;
    }
}
