using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)// Sound adjustment method

    {

        audioMixer.SetFloat("Volume", volume);
    }
    public void SetFullscreen(bool isFullscreen)// Full screen setting method
    {   

        Screen.fullScreen = isFullscreen;
    }
}
