using UnityEngine;

public class CoinPickupManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    private int m_Coins = 0;
    
    public int Coins
    {
        get => m_Coins;
        set => m_Coins = value;
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
