using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_HealthBar", menuName = "HealthBar")]
public class HealthBarTemplate : ScriptableObject
{
    public int maxHealth = 100;
    public int currentHealth;
}
