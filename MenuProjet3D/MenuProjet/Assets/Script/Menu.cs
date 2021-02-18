using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [UsedImplicitly] 
    public GameObject panel;

    public GameObject panelInstruction;
    public void HandleClick()//Permet le changement de scene
    {
        StartCoroutine(LoadSceneAsynchronously());
            
    }

    private IEnumerator LoadSceneAsynchronously()
    {
        UnityEngine.AsyncOperation op = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        while (!op.isDone) yield return null;
    }

    public void Setting()//Permet d'afficher le panel qui contient les differents parametres
    {
        panel.SetActive(true);
    }
    public void SettingClose()//Permet d'afficher le panel qui contient les differents parametres
    {
        panel.SetActive(false);
    }


    public void Exit()//Permet de quitter le jeu 
    {
        Application.Quit();
    }

    public void Instruction()//Permet d'afficher les instructions
    {
        panelInstruction.SetActive(true);
    }
    public void InstructionClose()//Permet d'afficher le panel qui contient les differents parametres
    {
        panelInstruction.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
