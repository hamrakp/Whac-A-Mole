using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip clickFx;

    public void ClickSound()// Method for playing a short sound
    {
        myFX.PlayOneShot(clickFx);
        
    }
}
