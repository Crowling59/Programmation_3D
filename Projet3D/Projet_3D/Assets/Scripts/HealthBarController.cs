using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour //Permet de controller la bar de vie du joueur
{
    [SerializeField] private Slider slider;
    
    [SerializeField] private Image fill;

    public Gradient gradient;
    public void SetMaxHealth(int health) //Fonction qui actualise la vie max
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int health) //Fonction qui actualise la vie actuelle
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
