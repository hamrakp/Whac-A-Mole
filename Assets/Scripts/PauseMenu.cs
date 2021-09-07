using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameISPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void OnGUI()
    {
        if(Event.current.Equals(Event.KeyboardEvent("X"))){
            if(GameISPaused == true){
                Resume();
            } else {
                Pause();
            }
        }       
    }

    public void Resume(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameISPaused = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameISPaused = true;
    }

    public void Quit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("WhacAMoleMenu");
    }
}
