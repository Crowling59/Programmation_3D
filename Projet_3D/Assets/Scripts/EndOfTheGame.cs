using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTheGame : MonoBehaviour
{
    public event EventHandler onPlayerEndOfTheGame;
    public event EventHandler onPlayerNotEndOfTheGame;
    
    public HealthBarTemplate healthBar;
    public TrackCheckpoints trackCheckpoints;

    private Boolean checkEnd = false;

    private Boolean cond = true;

    private int scoreBonus = 0;

    public int ScoreBonus => scoreBonus;


    void Update()
    {
        
        if (EndGame())
        {
            Event();
        }
        else
        {
            onPlayerNotEndOfTheGame?.Invoke(this,EventArgs.Empty);
        }
        
        
        
    }

    private void Event()
    {
        if (cond)
        {
            onPlayerEndOfTheGame?.Invoke(this,EventArgs.Empty);
            cond = false;
        }
        
    }

    private Boolean EndGame()
    {
        if (healthBar.currentHealth <= 0)
        {
            Debug.Log("DEAD FIN DE PARTIE !");
            
            return true ;
        }
        
        if((trackCheckpoints.NextCheckpointSingleIndex == 0) && checkEnd)
        {
            scoreBonus = 1000;
            Debug.Log("FIN DE PARTIE !");
            
            return true;
        }
        
        
        
        return false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        
        if (other.tag == "CheckpointEnd")
        {
            Ok();
        }
    }

    void Ok()
    {
        checkEnd = true;
    }
}
