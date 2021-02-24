using UnityEngine;

[CreateAssetMenu(fileName = "New_HealthBar", menuName = "HealthBar")]
public class HealthBarTemplate : ScriptableObject // Contient les informations sur la bar de vie
{
    public int maxHealth = 100;
    public int currentHealth;
}
