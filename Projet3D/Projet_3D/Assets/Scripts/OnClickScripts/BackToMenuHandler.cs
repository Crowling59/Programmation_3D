using UnityEngine;
using UnityEngine.SceneManagement;

namespace onClickScripts
{
    public class BackToMenuHandler : MonoBehaviour
    {
        public void OnClickMenu()  // Permet de revenir au menu principal
        {
            SceneManager.LoadScene(0);
        }
   
    }
}

