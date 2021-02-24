using UnityEngine;
using UnityEngine.Audio;

namespace menuPrincipal
{
    public class SettingMenuPrincipal : MonoBehaviour
    {
        public AudioMixer audioMixer;
    
    
        public void Start()
        {
            SetFullscreen(true);
        }
    
        public void SetVolume(float volume) //Permet de manipuler le son à l'aide d'un audiomixer
        {
            audioMixer.SetFloat("Volume", volume);
        }

        public void SetFullscreen(bool isFullscreen) //Permet de mettre le plein ecran
        {
            Screen.fullScreen = isFullscreen;
        }
   
    
    } 
}

