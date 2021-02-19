using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    
    public TextMeshProUGUI timerUI;
    private Boolean startTimer = false;

    private TimeSpan timePlaying;

    private float elapsedTime;

    public TimeSpan TimePlaying => timePlaying;

    void Start()
    {
        timerUI.text = "Time : 00:00:00";
        StartTimer();
    }

    public void StartTimer()
    {
        startTimer = true;
        elapsedTime = 0f;

        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        startTimer = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (startTimer)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timerUI.text = "Timer : " + timePlaying.ToString("mm':'ss'.'ff");

            yield return null; 
        }
        
    }
}
