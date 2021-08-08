using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Method for loading the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("WhacAMole");
    }
    // Method to end the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Method for loading the login scene
    public void ReturnLogin()
    {
        SceneManager.LoadScene("WhacAMoleLogin");
    }
}