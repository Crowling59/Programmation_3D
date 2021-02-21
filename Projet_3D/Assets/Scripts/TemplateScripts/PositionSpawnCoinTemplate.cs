using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinPosition", menuName = "CoinSpawnPosition")]
public class PositionSpawnCoinTemplate : ScriptableObject
{
    public List<Vector3> coinSpawnPosition = new List<Vector3>();
}
