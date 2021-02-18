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
    
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    
    // Start is called before the first frame update
    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> optionResolution = new List<string>();
        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            optionResolution.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolution = i;
            }
        }
        resolutionDropdown.AddOptions(optionResolution);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
        
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
