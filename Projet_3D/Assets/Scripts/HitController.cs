using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public HealthBarTemplate healthBarTemplate;

    public HealthBarController healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarTemplate.currentHealth = healthBarTemplate.maxHealth;
        healthBar.SetMaxHealth(healthBarTemplate.maxHealth);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        
        if (collision.gameObject.tag == "Decord_Small_Rock")
        {
            TakeDamage(5);
        }
        else if (collision.gameObject.tag == "Decord_Normal_Rock")
        {
            TakeDamage(10);
        }
        else if (collision.gameObject.tag == "Decord_Rock_wall")
        {
            TakeDamage(20);
        }
    }


    void TakeDamage(int damage)
    {
        healthBarTemplate.currentHealth -= damage;
        if (healthBarTemplate.currentHealth < 0)
        {
            healthBarTemplate.currentHealth = 0;
        }
        
        healthBar.SetHealth(healthBarTemplate.currentHealth);
    }
}
