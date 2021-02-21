using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonHandler : MonoBehaviour
{
   public void OnClick()
   {
      SceneManager.LoadScene(1);
   }
}
