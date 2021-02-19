using UnityEngine;
using UnityEngine.Audio;


public class Setting : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    
    public void Start()
    {
        SetFullscreen(true);
    }
    
    public void SetVolume(float volume)//Permet de manipuler le son à l'aide d'un audiomixer
    {
        audioMixer.SetFloat("Volume", volume);
        //Debug.Log(volume);
    }

    public void SetFullscreen(bool isFullscreen)//Permet de mettre le plein ecran
    {
        Screen.fullScreen = isFullscreen;
    }
   
    
}
