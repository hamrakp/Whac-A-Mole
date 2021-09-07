using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public Text errorMessage;
    public InputField email;
    public InputField password;
    
    // Sending a password reset request
    public void ResetButton()
    {
        // Create a request with parameters from the email input field and our unique title ID
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email.text,
            TitleId = "E0B82" // Please change this value to your own TitleId from PlayFab Game Manager
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, passwordReset, Error);// Send a password reset request
    }

    public void RegisterButton()// Registration using email and password
    {
        var request = new RegisterPlayFabUserRequest // Create a request with parameters from input fields
        {
            Email = email.text,
            Password = password.text,
            RequireBothUsernameAndEmail = false// Parameter to log in without the need for a username
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, SuccessRegister, Error);
    }

    public void LoginButton()// Login  with parameters from login input fields
    {
        var request = new LoginWithEmailAddressRequest
        {

            Email = email.text,
            Password = password.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, SuccessLogin, Error);
    }
    void passwordReset(SendAccountRecoveryEmailResult result)// Method if password recovery was successful
    {

        errorMessage.text = "An email has been sent!";
    }

    void SuccessRegister(RegisterPlayFabUserResult result) // Method if the registration is successful, this will switch us to the main menu
    { 

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WhacAMoleMenu");
    }
    void SuccessLogin(LoginResult result) // Method if the login is successful
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WhacAMoleMenu");
    }
 
    void Error(PlayFabError error)// Method if login or registration fails
    {

        errorMessage.text = "Something went wrong!";
    }
}
