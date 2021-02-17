using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class SpawnCoinController : MonoBehaviour
{
    public PositionSpawnCoin positionSpawnCoin;
    
    void Start()
    {
        foreach (Vector3 vector3 in positionSpawnCoin.coinSpawnPosition)
        {
            GameObject coin= (GameObject) Instantiate(Resources.Load("Coin"),vector3, Quaternion.identity);
        }
    }

}
