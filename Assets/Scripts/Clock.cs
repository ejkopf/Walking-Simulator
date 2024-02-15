using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Clock : MonoBehaviour
{

    public float hour;
    public float minutes;
    public float seconds;
    public Text timeText;

    void Start()
    {
        hour = 11f;
        minutes = 0f;
        seconds = 0f;
        timeText.text = "11:00";
    }


    void FixedUpdate()
    {
        seconds += 0.004f; 
        if (seconds > 1f)
        {
            minutes += 1f;
            seconds = 0f;
        }
        if (minutes > 59f)
        {
            hour += 1f;
            minutes = 0f;
        }
        if (hour > 12f)
        {
            hour = 1f;
        }

        // render text
        if (minutes > 9)
        {
            timeText.text = hour.ToString() + ":" + minutes.ToString();
        } else
        {
            timeText.text = hour.ToString() + ":0" + minutes.ToString();
        }
        // Debug.Log(timeText.text);
    }
}