using System;
using UnityEngine;

public class EndOfTheGame : MonoBehaviour // Permet de gérer la fin de partie
{
    [SerializeField] private GameManager gameManager;
    
    private Boolean m_CheckEnd = false;

    private Boolean m_Cond = true;

    public event EventHandler ONPlayerEndOfTheGame;
    public event EventHandler ONPlayerNotEndOfTheGame;
    
    void Update()
    {
        //Si c'est la fin event 1 sinon event 2
        if (EndGame())
        {
            Event();
        }
        else
        {
            ONPlayerNotEndOfTheGame?.Invoke(this,EventArgs.Empty);
        }

    }

    private void Event() // Si c'est la fin on déclenche l'évenement de fin, où le menu est affiché + le calcul su score
    {
        if (m_Cond)
        {
            ONPlayerEndOfTheGame?.Invoke(this,EventArgs.Empty);
            m_Cond = false;
        }
        
    }

    private Boolean EndGame()
    {
        //Si la vie du joueur arrive à 0 c'est la fin
        if (gameManager.HealthBar.currentHealth <= 0)
        {
            return true ;
        }
        
        //Si le joueur passe le dernier checkpoint en ayant pris ceux d'avant, c'est la fin
        if((gameManager.TrackCheckPoints.NextCheckpointSingleIndex == 0) && m_CheckEnd)
        {
            gameManager.ScoreManager.ScoreBonus = 1000;

            return true;
        }
        
        
        
        return false;
    }
    
    void OnTriggerEnter(Collider other)
    {

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
