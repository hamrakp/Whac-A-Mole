using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class ScoreMenu : MonoBehaviour
{
    public Text ScoreText;
    public static int curr_score;
    public GameObject canvas;
    public Transform container;

    void Start()
    {
        curr_score = PlayerPrefs.GetInt("Score");// Get the current score from playerPrefs
    }

    void Error(PlayFabError error) { }// Error method
    
    public void GetLeaderboard()// Method for obtaining the highest score
    {
        var request = new GetLeaderboardRequest// Creating a request
        {
            StatisticName = "MaxScore", // Change this to connect to your PlayFab game title
            StartPosition = 0,
            MaxResultsCount = 4
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, Error);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)// Method for obtaining the table
    {
        foreach (Transform item in container)// Condition for updating the results will replace the old results with the new ones
            Destroy(item.gameObject);
        {
            foreach (var item in result.Leaderboard)// Cycle for listing results
            {
                GameObject rows = Instantiate(canvas, container);
                Text[] texts = rows.GetComponentsInChildren<Text>(); 
                texts[0].text = (item.Position +1).ToString();// Position starts from 1 element with the number 1 instead of 0
                texts[1].text = item.PlayFabId; // The second element is the Player Id, instead of the username due to the anonymity of the data
                texts[2].text = item.StatValue.ToString(); // Listing the value of MaxScore statistics

             }
        }
    }
    
    void Update()
    {
        ScoreText.text = curr_score.ToString();// Listing the current score

    }
}
