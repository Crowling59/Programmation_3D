using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BoosterController : MonoBehaviour
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
        gameManager.BoostTemplate.actualNumberBooster = gameManager.BoostTemplate.maxNumberBooster;
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (gameManager.BoostTemplate.actualNumberBooster > 0)
            {
                
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
                
                StopAllCoroutines();
                StartCoroutine(Boost());
        
                gameManager.BoostTemplate.actualNumberBooster -= 1; 
            }
            
        }
    }
    
    private IEnumerator Boost()
    {
        gameManager.BoatController.AccellerateSpeed = 5000f;
        yield return new WaitForSeconds(3);
        gameManager.BoatController.AccellerateSpeed = 2500f;
    }
    
}
