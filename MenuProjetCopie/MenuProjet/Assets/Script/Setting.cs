using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public AudioMixer audioMixer;
    
   
    
    // Start is called before the first frame update
    public void Start()
    {
       
        
        Screen.fullScreen = true;
    }
    
    public void SetVolume(float volume)//Permet de manipuler le son à l'aide d'un audiomixer
    {
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }

    public void SetFullscreen(bool isFullscreen)//Permet de mettre le plein ecran
    {
        Screen.fullScreen = isFullscreen;
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
