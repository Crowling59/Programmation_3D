using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class SpawnCoinController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        foreach (Vector3 vector3 in gameManager.PositionSpawnCoin.coinSpawnPosition)
        {
             Instantiate(Resources.Load("Coin"),vector3, Quaternion.identity);
        }
    }

}
