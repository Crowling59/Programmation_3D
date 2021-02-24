using UnityEngine;
using UnityEngine.SceneManagement;


namespace onClickScripts
{
    public class RestartButtonHandler : MonoBehaviour
    {
        public void OnClick() // Permet de charger la scène de jeu
        {
            SceneManager.LoadScene(1);
        }
    }
}

