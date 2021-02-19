using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RestartButtonHandler : MonoBehaviour
{
   public void OnClick()
   {
      SceneManager.LoadScene("SampleScene");
   }
}
