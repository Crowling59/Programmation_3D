using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreTemplate scoreTemplate;

    public HitController hitController;

    public CoinPickupManager coinPickupManager;

    public TimerManager timerManager;
    
    public EndOfTheGame endOfTheGame;
    
    private int scoreHealth;
    private int scoreCoins;
    private int scoreTime = 1000;
    private int scoreBonusEnd=0;
    private Double Time;

    public int ScoreHealth => scoreHealth;
    public int ScoreCoins => scoreCoins;

    public int ScoreTime => scoreTime;

    public int ScoreBonusEnd => scoreBonusEnd;

    public void CalculScore()
    {
        
        Time = timerManager.TimePlaying.TotalSeconds;
        while (Time > 1) {
            scoreTime -= 5;
            Time -= 1;
        }

        scoreBonusEnd = endOfTheGame.ScoreBonus;
        scoreHealth = hitController.healthBarTemplate.currentHealth * 5;
        scoreCoins = coinPickupManager.Coins * 10;
        scoreTemplate.score = scoreHealth + scoreCoins + scoreBonusEnd + scoreTime;
    }
}
