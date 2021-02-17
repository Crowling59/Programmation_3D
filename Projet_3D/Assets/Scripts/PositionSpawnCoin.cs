using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinPosition", menuName = "CoinSpawnPosition")]
public class PositionSpawnCoin : ScriptableObject
{
    public List<Vector3> coinSpawnPosition = new List<Vector3>();
}
