using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class SpawnCoinController : MonoBehaviour //Permet de faire spawn les coins aux emplacements renseignés venant du ScriptableObject correspondant
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
