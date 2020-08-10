using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.Analytics;
using System;

public class Ads : MonoBehaviour
{
    string gameId = "3688703";
    string videoPlacementId = "video";
    string bannerPlacementId = "banner";
    bool testMode = false;
    bool isPurchased;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        isPurchased = Convert.ToBoolean(PlayerPrefs.GetInt("Purchased"));
    }      
    public void StopAds()
    {
        isPurchased = Convert.ToBoolean(PlayerPrefs.GetInt("Purchased"));   
        if (!isPurchased)
        {
            Advertisement.Initialize(gameId, testMode);            
        }
    }
    public void ShowAds()
    {
        if(!isPurchased)
            Advertisement.Show(videoPlacementId);
    }
}
