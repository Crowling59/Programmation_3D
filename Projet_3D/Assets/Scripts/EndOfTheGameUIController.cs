using TMPro;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class EndOfTheGameUIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private TextMeshProUGUI contenuUI;

    private void Start()
    {
        gameManager.EndOfTheGame.ONPlayerEndOfTheGame += TrackEndOfTheGame_OnPlayerEndOfTheGame;
        gameManager.EndOfTheGame.ONPlayerNotEndOfTheGame += TrackNotEndOfTheGame_OnPlayerNotEndOfTheGame;

        Hide();
    }

   

    private void TrackEndOfTheGame_OnPlayerEndOfTheGame(object sender, System.EventArgs e)
    {
        gameManager.TimerManager.EndTimer();
        gameManager.BoatController.BoatRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        gameManager.ScoreManager.CalculScore();
        contenuUI.text = "Récap du score : \n" + " - Bonus fin de course: " + gameManager.ScoreManager.ScoreBonusEnd + "\n"
                                     + " - Score temps restant: " + gameManager.ScoreManager.ScoreTime + "\n"
                                     + " - Score vie restante: " +gameManager.ScoreManager.ScoreHealth + "\n"
                                     + " - Score nombre de pièces: " + gameManager.ScoreManager.ScoreCoins + "\n"
                                     + "Score total: " + gameManager.ScoreTemplate.score;
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
