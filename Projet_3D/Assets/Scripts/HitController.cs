using UnityEngine;

public class HitController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioClip rockSound;

    void Start()
    {
        gameManager.HealthBar.currentHealth = gameManager.HealthBar.maxHealth;
        gameManager.HealthBarController.SetMaxHealth(gameManager.HealthBar.maxHealth);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        
        if (collision.gameObject.CompareTag("Decord_Small_Rock"))
        {
            AudioSource.PlayClipAtPoint(rockSound,transform.position,1f);
            TakeDamage(5);
        }
        else if (collision.gameObject.CompareTag("Decord_Normal_Rock"))
        {
            AudioSource.PlayClipAtPoint(rockSound,transform.position,1f);
            TakeDamage(10);
        }
        else if (collision.gameObject.CompareTag("Decord_Rock_wall"))
        {
            AudioSource.PlayClipAtPoint(rockSound,transform.position,1f);
            TakeDamage(20);
        }
    }


    void TakeDamage(int damage)
    {
        gameManager.HealthBar.currentHealth -= damage;
        if (gameManager.HealthBar.currentHealth < 0)
        {
            gameManager.HealthBar.currentHealth = 0;
        }
        
        gameManager.HealthBarController.SetHealth(gameManager.HealthBar.currentHealth);
    }
}
