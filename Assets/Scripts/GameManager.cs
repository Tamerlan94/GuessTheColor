using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Toggle muteToggle;
    public Button leaderboards;
    public Button nextMusic;
    public AudioManager audioManager;
    private void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => {
            if (success) Debug.Log("Удачно вошёл");
            else Debug.Log("Не удачно вошёл");
        });

        audioManager = FindObjectOfType<AudioManager>();
        startButton.onClick.AddListener(GameStart);
        muteToggle.onValueChanged.AddListener(Mute);
        leaderboards.onClick.AddListener(ShowLeaderboards);
        nextMusic.onClick.AddListener(NextMusic);
    }

    private void GameStart()
    {
        //SceneManager.LoadScene(1);
        FindObjectOfType<LeveLoader>().LoadNextLevel();
    }
    public void Mute(bool a)
    {
        if (a)
        {
            audioManager.source.mute = true;
        }
        else
        {
            audioManager.source.mute = false;
        }
    }
    public void NextMusic()
    {
        audioManager.NextMusic();
    }
    public void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }
    public void RestorePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
