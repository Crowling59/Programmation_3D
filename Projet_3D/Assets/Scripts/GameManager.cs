using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    [Header("Booster Settings")]

    [SerializeField] private BoostTemplate boostTemplate;
    public BoostTemplate BoostTemplate => boostTemplate;

    [Space(5)]
    
    [Header("Boat Settings")]

    [SerializeField] private BoatController boatController;
    public BoatController BoatController => boatController;

    [Space(5)]
    
    [Header("Checkpoints Settings")]
    
    [SerializeField] private TrackCheckpoints trackCheckPoints;

    public TrackCheckpoints TrackCheckPoints => trackCheckPoints;
    

    [Space(5)]
    
    [Header("Health Settings")] 
    
    [SerializeField] private HealthBarTemplate healthbar;
    public HealthBarTemplate HealthBar => healthbar;

    [SerializeField] private HitController hitController;
    
    public HitController HitController => hitController;
    
    [SerializeField] private HealthBarController healthBarController;
    public HealthBarController HealthBarController => healthBarController;
    
    
    [Space(5)]
    
    [Header("Coins Settings")]
    
    [SerializeField] private CoinPickupManager coinPickupManager;
    
    public CoinPickupManager CoinPickupManager => coinPickupManager;
    
    [SerializeField] private TextMeshProUGUI coinsUI;
    
    [SerializeField] private PositionSpawnCoinTemplate positionSpawnCoin;

    public PositionSpawnCoinTemplate PositionSpawnCoin => positionSpawnCoin;

    public TextMeshProUGUI CoinsUI => coinsUI;

    [Space(5)]
    
    [Header("Score Settings")]
    
    [SerializeField] private ScoreTemplate scoreTemplate;
    
    public ScoreTemplate ScoreTemplate => scoreTemplate;
    
    [SerializeField] private ScoreManager scoreManager;
    
    public ScoreManager ScoreManager => scoreManager;


    [Space(5)] 
    
    [Header("Timer Settings")]
    
    [SerializeField] private TimerManager timerManager;
    public TimerManager TimerManager => timerManager;
    

    [Space(5)]
    
    [Header("EndOfTheGame Settings")] 
    
    [SerializeField] private EndOfTheGame endOfTheGame;
    public EndOfTheGame EndOfTheGame => endOfTheGame;


}
