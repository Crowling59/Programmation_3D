using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private int m_ScoreBonus = 0;
    public int ScoreBonus
    {
        get => m_ScoreBonus;
        set => m_ScoreBonus = value;
    }
    
    private int m_ScoreHealth;
    
    public int ScoreHealth
    {
        get => m_ScoreHealth;
        set => m_ScoreHealth = value;
    }

    private int m_ScoreCoins;
    
    public int ScoreCoins
    {
        get => m_ScoreCoins;
        set => m_ScoreCoins = value;
    }

    private int m_ScoreTime = 1000;
    
    public int ScoreTime
    {
        get => m_ScoreTime;
        set => m_ScoreTime = value;
    }

    private int m_ScoreBonusEnd=0;
    
    public int ScoreBonusEnd
    {
        get => m_ScoreBonusEnd;
        set => m_ScoreBonusEnd = value;
    }

    public void CalculScore()
    {
        
        gameManager.TimerManager.Time = gameManager.TimerManager.TimePlaying.TotalSeconds;
        while (gameManager.TimerManager.Time > 1) {
            m_ScoreTime -= 5;
            gameManager.TimerManager.Time -= 1;
        }

        m_ScoreBonusEnd = m_ScoreBonus;
        m_ScoreHealth = gameManager.HealthBar.currentHealth * 5;
        m_ScoreCoins = gameManager.CoinPickupManager.Coins * 10;
        gameManager.ScoreTemplate.score = m_ScoreHealth + m_ScoreCoins + m_ScoreBonusEnd + m_ScoreTime;
    }
}
