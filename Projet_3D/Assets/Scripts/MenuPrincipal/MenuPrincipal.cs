using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace menuPrincipal
{
    public class MenuPrincipal : MonoBehaviour
    {
        [UsedImplicitly] 
        public GameObject panel;

        public GameObject panelInstruction;
        public void HandleClick() //Permet le changement de scene
        {
            StartCoroutine(LoadSceneAsynchronously());
            
        }

        private IEnumerator LoadSceneAsynchronously()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(1);
            while (!op.isDone) yield return null;
        }

        public void Setting() //Permet d'afficher le panel qui contient les differents parametres
        {
            panel.SetActive(true);
        }
        public void SettingClose() //Permet d'afficher le panel qui contient les differents parametres
        {
            panel.SetActive(false);
        }


        public void Exit() //Permet de quitter le jeu 
        {
            Application.Quit();
        }

        public void Instruction() //Permet d'afficher les instructions
        {
            panelInstruction.SetActive(true);
        }
        public void InstructionClose() //Permet d'afficher le panel qui contient les differents parametres
        {
            panelInstruction.SetActive(false);
        }

    }

}
