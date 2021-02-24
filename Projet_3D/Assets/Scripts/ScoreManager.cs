using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private int m_ScoreBonus = 0;
    public int ScoreBonus
    {
        set => m_ScoreBonus = value;
    }
    
    private int m_ScoreHealth;
    
    public int ScoreHealth
    {
        get => m_ScoreHealth;
    }

    private int m_ScoreCoins;
    
    public int ScoreCoins
    {
        get => m_ScoreCoins;
    }

    private int m_ScoreTime = 1000;
    
    public int ScoreTime
    {
        get => m_ScoreTime;
    }

    private int m_ScoreBonusEnd=0;
    
    public int ScoreBonusEnd
    {
        get => m_ScoreBonusEnd;
    }

    public void CalculScore() //Permet de calculer le score du joueur en fin de partie
    {
        
        gameManager.TimerManager.Time = gameManager.TimerManager.TimePlaying.TotalSeconds;
        while (gameManager.TimerManager.Time > 1) { // On enlève 5 de score au 1000 de départ par seconde 
            m_ScoreTime -= 5;
            gameManager.TimerManager.Time -= 1;
        }

        m_ScoreBonusEnd = m_ScoreBonus;
        m_ScoreHealth = gameManager.HealthBar.currentHealth * 5; // 5 de score par pdv
        m_ScoreCoins = gameManager.CoinPickupManager.Coins * 10; // 10 de score par coin
        gameManager.ScoreTemplate.score = m_ScoreHealth + m_ScoreCoins + m_ScoreBonusEnd + m_ScoreTime;
    }
}
