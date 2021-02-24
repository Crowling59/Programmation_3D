using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BoosterController : MonoBehaviour // Permet de controller les boosters
{
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private Image imageBoosterUI;
    public Image ImageBoosterUI => imageBoosterUI;
    
    [SerializeField] private Image imageBoosterUI2;
    public Image ImageBoosterUI2 => imageBoosterUI2;
    
    [SerializeField] private Image imageBoosterUI3;
    public Image ImageBoosterUI3 => imageBoosterUI3;
    
    void Start()
    {
        gameManager.BoostTemplate.actualNumberBooster = gameManager.BoostTemplate.maxNumberBooster; // On initialise au max le nombre de booster au départ
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) // Si click droit
        {
            if (gameManager.BoostTemplate.actualNumberBooster > 0)
            {
                //On détruit l'image du booster correspondant une fois utilisé
                if (gameManager.BoostTemplate.actualNumberBooster == 3)
                {
                    Destroy(ImageBoosterUI3);
                }
                else if (gameManager.BoostTemplate.actualNumberBooster == 2)
                {
                    Destroy(ImageBoosterUI2);
                }
                else if (gameManager.BoostTemplate.actualNumberBooster == 1)
                {
                    Destroy(ImageBoosterUI);
                }
                //On active le booster
                StopAllCoroutines();
                StartCoroutine(Boost());
        
                gameManager.BoostTemplate.actualNumberBooster -= 1; 
            }
            
        }
    }
    
    private IEnumerator Boost() // Permet d'augmenter l'acceleration pendant 3 secondes
    {
        gameManager.BoatController.AccelerateSpeed = 5000f;
        yield return new WaitForSeconds(3);
        gameManager.BoatController.AccelerateSpeed = 2500f;
    }
    
}
