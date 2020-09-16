﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 15.49999f;
    float totalTime;
    float minutes;
    string min;
    string sec;
    float seconds;
    bool start;


    [SerializeField] TextMeshProUGUI countdown;

    private void Start()
    {

        currentTime = startingTime;
        countdown.text = timeToString(currentTime);
        bool start = false;
     
    }

    private void Update()
    {

        StartCoroutine(Delay());
        if (start)
        {
            if (currentTime >= 10)
            {
                currentTime -= 1 * Time.deltaTime;

                countdown.text = timeToString(currentTime);
            }
            else if (currentTime < 10 && currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;
                
                countdown.text = timeToString(currentTime);
                countdown.color = Color.red;

                countdown.fontSize = getFontSize(currentTime);
            }
            else if (currentTime <= 0)
            {
                countdown.text = timeToString(currentTime);
                countdown.color = Color.red;
                countdown.fontStyle = FontStyles.Bold;
            }

        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        start = true;
    }

    string timeToString(float time)
    {
        if (currentTime > 60)
        {
            minutes = currentTime / 60;
            min = minutes.ToString("0");
            seconds = currentTime % 60;
            sec = seconds.ToString("00");

            return (min + ":" + sec);
        }
        if (currentTime >= 10)
        {
            return currentTime.ToString("0");
        }
        else if (currentTime < 10 && currentTime > 0)
        {
            return currentTime.ToString("0.0");
        }
        else if (currentTime <= 0)
        {
            return "GAME OVER";
        }
        return "GAME OVER";
    }

    int getFontSize(float time)
    {
        float perc = time % 1;

        return (int)Mathf.Lerp(40, 50, perc);
    }
}
