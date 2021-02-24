using UnityEngine;

public class CoinPickupManager : MonoBehaviour // Permet de récupérer des coins et d'augmenter le compteur de coins
{
    [SerializeField] private AudioClip coinSound;
    private int m_Coins = 0;
    
    public int Coins
    {
        get => m_Coins;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            m_Coins++;
            AudioSource.PlayClipAtPoint(coinSound,transform.position,2f);
            Destroy(other.gameObject);
        }
    }
}
