using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class EndOfTheGameUIController : MonoBehaviour
{
    [SerializeField] private EndOfTheGame endOfTheGame;
    public TextMeshProUGUI contenuUI;
    public ScoreManager scoreManager;

    public Rigidbody boatRigidbody;
    public TimerManager timerManager;
    

    private void Start()
    {
        endOfTheGame.onPlayerEndOfTheGame += TrackEndOfTheGame_OnPlayerEndOfTheGame;
        endOfTheGame.onPlayerNotEndOfTheGame += TrackNotEndOfTheGame_OnPlayerNotEndOfTheGame;

        Hide();
    }

   

    private void TrackEndOfTheGame_OnPlayerEndOfTheGame(object sender, System.EventArgs e)
    {
        boatRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        timerManager.EndTimer();
        scoreManager.CalculScore();
        contenuUI.text = "Récap du score : \n" +" - Score temps restant: " + scoreManager.ScoreTime + "\n" + " - Score vie restante: " + scoreManager.ScoreHealth + "\n" + " - Score nombre de pièces: " + scoreManager.ScoreCoins + "\n" + "Score total: " + scoreManager.scoreTemplate.score;
        Show();
        Cursor.lockState = CursorLockMode.None;
    }
    
    private void TrackNotEndOfTheGame_OnPlayerNotEndOfTheGame(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
