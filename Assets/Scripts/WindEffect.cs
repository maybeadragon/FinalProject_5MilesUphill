using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindEffect : MonoBehaviour
{
    private float windLevel = 0f;
    private float maxWind = 100f;

    public Slider windBar;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        windBar.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            windLevel = 0.05f;
            windBar.value = windLevel;
            windBar.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (windLevel < maxWind)
            {
                windLevel += 0.01f * Time.deltaTime;
                player.transform.localPosition += new Vector3(0f, 0f, -1f * Time.deltaTime);
            }
            else
            {
                windLevel = maxWind;
                GameManager.LoadScene("FailScreen");
            }
        }
        windBar.value = windLevel;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            windLevel = 0f;
            windBar.value = windLevel;
            windBar.gameObject.SetActive(false);
        }
    }
}
