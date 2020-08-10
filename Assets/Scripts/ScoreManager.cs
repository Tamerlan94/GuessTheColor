using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    public int scoreCount;
    public int hiScoreCount;  
    
    public static ScoreManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        hiScoreCount = PlayerPrefs.GetInt("Hiscore", 0);
    }

    public void AddScore(int score)
    {
        scoreCount += score;
        FindObjectOfType<UITextShow>().ShowScore();
    }   
    public void AddHiScore()
    {
        if(scoreCount >= hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("Hiscore", hiScoreCount);
        }
    }
    public void UpdateLeaderboardsScore()
    {
        if(PlayerPrefs.GetInt("Hiscore",0) == 0)
        {
            return;
        }
        Social.ReportScore(PlayerPrefs.GetInt("Hiscore", 1), GPGSIds.leaderboard_hiscore, (bool success) =>
         {
             if (success)
             {
                 PlayerPrefs.SetInt("Hiscore", 0);
             }
         });
    }
}
