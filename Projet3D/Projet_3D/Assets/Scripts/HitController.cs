using UnityEngine;

public class HitController : MonoBehaviour //Permet de controller les dégâts reçus
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
        //Si le tag de l'objet avec qui le joueur collide est du type correspondant aux différents rochers ci-dessous alors il prend les dégâts correspondants + un son
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


    void TakeDamage(int damage) // Si la vie du joueur est strictement supérieure à 0, il prend les dégâts
    {
        gameManager.HealthBar.currentHealth -= damage;
        if (gameManager.HealthBar.currentHealth < 0)
        {
            gameManager.HealthBar.currentHealth = 0;
        }
        
        gameManager.HealthBarController.SetHealth(gameManager.HealthBar.currentHealth);
    }
}
