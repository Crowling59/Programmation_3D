using System;
using System.Collections;
using TMPro;
using UnityEngine;


public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerUI;

    private Boolean m_StartTimer = false;

    private float m_ElapsedTime;
    

    private TimeSpan m_TimePlaying;

    public TimeSpan TimePlaying
    {
        get => m_TimePlaying;
        set => m_TimePlaying = value;
    }


    private Double m_Time;
    
    public Double Time
    {
        get => m_Time;
        set => m_Time = value;
    }

    void Start()
    {
        timerUI.text = "Time : 00:00:00";
        StartTimer();
    }

    public void StartTimer()
    {
        m_StartTimer = true;
        m_ElapsedTime = 0f;

        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        m_StartTimer = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (m_StartTimer)
        {
            m_ElapsedTime += UnityEngine.Time.deltaTime;
            m_TimePlaying = TimeSpan.FromSeconds(m_ElapsedTime);
            timerUI.text = "Timer : " + m_TimePlaying.ToString("mm':'ss'.'ff");

            yield return null; 
        }
        
    }
}
