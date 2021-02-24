using UnityEngine;

public class TrackNumberOfCoins : MonoBehaviour //Permet de gérer l'affichage des coins sur l'UI du joueur
{
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        gameManager.CoinsUI.text = "<color=yellow>0</color>";
    }

    
    void Update()
    {
        gameManager.CoinsUI.text = "<color=yellow>" + gameManager.CoinPickupManager.Coins + "</color>";
    }
}
