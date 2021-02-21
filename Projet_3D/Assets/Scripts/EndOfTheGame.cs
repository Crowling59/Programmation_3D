using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTheGame : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private Boolean m_CheckEnd = false;

    private Boolean m_Cond = true;

    public event EventHandler ONPlayerEndOfTheGame;
    public event EventHandler ONPlayerNotEndOfTheGame;
    
    void Update()
    {
        
        if (EndGame())
        {
            Event();
        }
        else
        {
            ONPlayerNotEndOfTheGame?.Invoke(this,EventArgs.Empty);
        }

    }

    private void Event()
    {
        if (m_Cond)
        {
            ONPlayerEndOfTheGame?.Invoke(this,EventArgs.Empty);
            m_Cond = false;
        }
        
    }

    private Boolean EndGame()
    {
        if (gameManager.HealthBar.currentHealth <= 0)
        {
            Debug.Log("DEAD FIN DE PARTIE !");
            
            return true ;
        }
        
        if((gameManager.TrackCheckPoints.NextCheckpointSingleIndex == 0) && m_CheckEnd)
        {
            gameManager.ScoreManager.ScoreBonus = 1000;
            Debug.Log("FIN DE PARTIE !");
            
            return true;
        }
        
        
        
        return false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        
        if (other.gameObject.CompareTag("CheckpointEnd"))
        {
            Ok();
        }
    }

    void Ok()
    {
        m_CheckEnd = true;
    }
}
