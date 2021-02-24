using UnityEngine;

[CreateAssetMenu(fileName = "ScorePlayer", menuName = "Score")]
public class ScoreTemplate : ScriptableObject // Contient le score du joueur
{
    public int score = 0;
}
