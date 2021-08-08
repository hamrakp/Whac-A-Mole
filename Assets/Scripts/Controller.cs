using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class Controller : MonoBehaviour
{
    public GameObject moleContainer; 
    public GameObject countdownCanvas;
    public Player player;
    public TextMesh text;
    public Mole[] moles;
    public float spawnDuration = 3f;
    public float spawnDecrement = 0.2f;
    public float minimumSpawnDuration = 2f;
    public float gameTimer = 40f;
    private float spawnTimer = 0f;
    float countdownTime = 0f;
    float delayTime = 5f;

    [SerializeField] Text countdownText; 

    // Start is called before the first frame update
    void Start()
    {
        countdownTime = delayTime;
        // Set the initial timer countdown to 5

        moles = moleContainer.GetComponentsInChildren<Mole>();
        // Add Mole objects from the MoleContainer object to the moles field

        if (countdownCanvas.activeSelf == false)
        // Condition if the text element is inactive at the beginning of the game
        {
            countdownCanvas.SetActive(true);
            // Activate the countdownCanvas object
        }

        PlayfabLogin();
 
    }
    // Method to log in to playfab using the unique ID of our game title
    void PlayfabLogin()
    {
        // Create a login request using an ID
        var request = new LoginWithCustomIDRequest
        {
            TitleId = "Titleid",
            CreateAccount = true
            // Automatic create an account in PlayFab if none is associated with our id
        };
        PlayFabClientAPI.LoginWithCustomID(request, Success, Error);
        // Login via ID using API
    }

    void Success(LoginResult result) { }// Method if the login to PlayFab was successful
    void Error(PlayFabError error) { }// Method if login failed
    void UpdateLeaderboard(UpdatePlayerStatisticsResult result) { }
 
    public void SendLeaderboard(int hitScore)
    // Method for sending the score to the server
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            // PlayFab request to send statistics
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate// Send score to the tables with the value of the last recorded score
                {
                    StatisticName = "HitScore",
                    Value = hitScore
                },
                 new StatisticUpdate
                {
                    StatisticName = "MaxScore",
                    Value = hitScore
                },
                  new StatisticUpdate
                {
                    StatisticName = "MinScore",
                    Value = hitScore
                }
            }
        };
                PlayFabClientAPI.UpdatePlayerStatistics(request, UpdateLeaderboard, Error);

    }  

    // Update is called once per frame
    void Update()
    {
        countdownTime -= 1 * Time.deltaTime;// Countdown to the beginning of the game
        countdownText.text = countdownTime.ToString("0");
        // Set the time output to text, to an integer
        if (countdownTime <= 0) // Set to turn off the text of the initial countdown after the time has elapsed
        {
            countdownCanvas.SetActive(false);

            countdownTime = 0;

            if (gameTimer > 0f)// Condition if the game is in progress
            {
                text.text = "Time:" + Mathf.Floor(gameTimer) + "\nScore:" + player.score;// Score and time listing

            }

            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                moles[Random.Range(0, moles.Length)].Rise();
                spawnDuration -= spawnDecrement;
                if (spawnDuration < minimumSpawnDuration)// Condition for keeping the objects in the desired position until the next iteration
                {
                    spawnDuration = minimumSpawnDuration;
                }

                spawnTimer = spawnDuration;

            }

            gameTimer -= Time.deltaTime;

            if (gameTimer <= 0f)// If the game ends
            {
                SendLeaderboard(player.score);// Call the method to send statistics with the recorded score parameter
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WhacAMoleMenu"); // Change the scene on the menu
            }
        }       
    }
}
