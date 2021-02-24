using TMPro;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class EndOfTheGameUIController : MonoBehaviour //Permet de gérer le contenu des évenements de fin de partie + l'UI de fin de partie
{
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private TextMeshProUGUI contenuUI;

    private void Start()
    {
        //On ajoute nos actions aux évenements
        gameManager.EndOfTheGame.ONPlayerEndOfTheGame += TrackEndOfTheGame_OnPlayerEndOfTheGame;
        gameManager.EndOfTheGame.ONPlayerNotEndOfTheGame += TrackNotEndOfTheGame_OnPlayerNotEndOfTheGame;

        //De base le menu est caché, il ne le sera plus si une condition de fin de partie est actif
        Hide();
    }

   

    private void TrackEndOfTheGame_OnPlayerEndOfTheGame(object sender, System.EventArgs e) // fonction de fin de game
    {
        //On stop le timer
        gameManager.TimerManager.EndTimer();
        //On freeze les mouvements du bateau
        gameManager.BoatController.BoatRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //On calcul le score
        gameManager.ScoreManager.CalculScore();
        //On affiche le score
        contenuUI.text = "Récap du score : \n" + " - Bonus fin de course: " + gameManager.ScoreManager.ScoreBonusEnd + "\n"
                                     + " - Score temps restant: " + gameManager.ScoreManager.ScoreTime + "\n"
                                     + " - Score vie restante: " +gameManager.ScoreManager.ScoreHealth + "\n"
                                     + " - Score nombre de pièces: " + gameManager.ScoreManager.ScoreCoins + "\n"
                                     + "Score total: " + gameManager.ScoreTemplate.score;
        Show();
        //On délock le curseur pour que le joueur puisse cliquer sur recommencer ou menu principal
        Cursor.lockState = CursorLockMode.None;
    }

    private void TrackNotEndOfTheGame_OnPlayerNotEndOfTheGame(object sender, System.EventArgs e) // fonction pour cacher le menu tant que ce n'est pas la fin
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
