using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BoosterController : MonoBehaviour
{
    public BoostTemplate boostTemplate;
    public BoatController boatController;

    public Image imageUI;
    public Image imageUI2;
    public Image imageUI3;

    
    void Start()
    {
        boostTemplate.actualNumberBooster = boostTemplate.maxNumberBooster;
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (boostTemplate.actualNumberBooster > 0)
            {
                
                if (boostTemplate.actualNumberBooster == 3)
                {
                    Destroy(imageUI3);
                }
                else if (boostTemplate.actualNumberBooster == 2)
                {
                    Destroy(imageUI2);
                }
                else if (boostTemplate.actualNumberBooster == 1)
                {
                    Destroy(imageUI);
                }
                
                StopAllCoroutines();
                StartCoroutine(Boost());
        
                boostTemplate.actualNumberBooster -= 1; 
            }
            
        }
    }
    
    private IEnumerator Boost()
    {
        boatController.accellerateSpeed = 3000f;
        yield return new WaitForSeconds(3);
        boatController.accellerateSpeed = 1800f;
    }
    
    /*public void SetMaxBoost(int numberBoost)
    {
        boostTemplate.maxNumberBooster = numberBoost;
    }
    
    public void SetBoost(int numberBoost)
    {
        boostTemplate.actualNumberBooster = numberBoost;
    }*/
}
