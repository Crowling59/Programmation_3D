using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuHandler : MonoBehaviour
{
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
   
}
