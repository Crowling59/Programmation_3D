using UnityEngine;


[CreateAssetMenu(fileName = "New_Booster", menuName = "Booster")]
public class BoostTemplate : ScriptableObject // Contient les informations sur les boosters
{
    public int maxNumberBooster = 3;
    public int actualNumberBooster = 3;
} 


