using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITextShow : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    [Header("Canvas group")]    
    public CanvasGroup loseGame_canvas;
    public CanvasGroup pauseGame_canvas;
    [Header("Buttons")]
    public Button retry;
    public Button home;

    public Button pause;
    public Button secondPause;
    private bool isPause;

    private static int loseCount = 0;
    private Ads ads;

    private void Start()
    {
        FindObjectOfType<BallControl>().EndGameStarted += LoseGame;
        ads = FindObjectOfType<Ads>();

        retry.onClick.AddListener(Retry);
        home.onClick.AddListener(Home);
        pause.onClick.AddListener(Pause);
        secondPause.onClick.AddListener(Pause);
    }
    public void ShowScore()
    {
        scoreText.text = ScoreManager.instance.scoreCount.ToString();       
    }

    public void LoseGame()
    {
        loseGame_canvas.DOFade(1f, 1f).SetUpdate(UpdateType.Normal, true);
        loseGame_canvas.blocksRaycasts = true;

        hiScoreText.text = ScoreManager.instance.hiScoreCount.ToString();
        ScoreManager.instance.UpdateLeaderboardsScore();

        Time.timeScale = 0f;

        //реклама      
        loseCount++;
        if(loseCount == 5)
        {
            ads.ShowAds();
            loseCount = 0;
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game1");
        Time.timeScale = 1f;
        ScoreManager.instance.scoreCount = 0;
    }
    public void Home()
    {
        //SceneManager.LoadScene("Menu");
        FindObjectOfType<LeveLoader>().LoadBackLevel();
        Time.timeScale = 1f;
        ScoreManager.instance.scoreCount = 0;
    }
    private void Pause()
    {
        isPause = !isPause;
        if (isPause)
        {
            pauseGame_canvas.DOFade(1f, .2f).SetUpdate(UpdateType.Normal, true);
            pauseGame_canvas.blocksRaycasts = true;
            Time.timeScale = 0f;
        }
        else if(!isPause)
        {
            pauseGame_canvas.DOFade(0f, .2f).SetUpdate(UpdateType.Normal, true);
            pauseGame_canvas.blocksRaycasts = false;
            Time.timeScale = 1f;
        }
    }
}

