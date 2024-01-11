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
    public TextMesh statusText; // Renamed from 'text' for clarity
    public Mole[] moles;
    public float spawnDuration = 3f;
    public float spawnDecrement = 0.2f;
    public float minimumSpawnDuration = 0.5f; // Reduced to make the game more challenging over time
    public float gameTimer = 40f;
    private float spawnTimer;
    
    [SerializeField] private Text countdownText;
    private float countdownTime;
    private const float delayTime = 5f; // Made constant as it's a value that doesn't change

    private void Start()
    {
        countdownTime = delayTime;
        moles = moleContainer.GetComponentsInChildren<Mole>();
        countdownCanvas.SetActive(true);
        PlayfabLogin();
    }

    private void PlayfabLogin()
    {
        var request = new LoginWithCustomIDRequest
        {
            TitleId = "E0B82", 
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginError);
    }

    private void OnLoginSuccess(LoginResult result) { Debug.Log("Login Success"); }
    private void OnLoginError(PlayFabError error) { Debug.LogError("Login Error: " + error.GenerateErrorReport()); }
    
    private void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "HighScore", Value = score } // Just update the high score
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnLoginError);
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) { Debug.Log("Leaderboard Updated"); }

    private void Update()
    {
        // If the game is paused or not
        Time.timeScale = PauseMenu.GameISPaused ? 0f : 1f;

        HandleCountdown();
        HandleGameplay();
    }

    private void HandleCountdown()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = Mathf.CeilToInt(countdownTime).ToString();
            return; // Exit early to avoid running gameplay code
        }

        if (countdownCanvas.activeSelf)
        {
            countdownCanvas.SetActive(false);
        }
    }

    private void HandleGameplay()
    {
        if (gameTimer <= 0f)
        {
            FinishGame();
            return; // Exit early if game is over
        }

        // Update game timer and status text
        gameTimer -= Time.deltaTime;
        statusText.text = $"Time: {Mathf.Floor(gameTimer)}\nScore: {player.score}";

        // Handle mole spawning
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            moles[Random.Range(0, moles.Length)].Rise();
            spawnTimer = Mathf.Max(spawnDuration -= spawnDecrement, minimumSpawnDuration);
        }
    }

    private void FinishGame()
    {
        SendLeaderboard(player.score);
        SceneManager.LoadSceneAsync("WhacAMoleMenu"); // It's safe to call LoadSceneAsync multiple times because it won't reload if already loading
    }
}
