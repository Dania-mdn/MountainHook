using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    public int ads = 0;
    //реклама
    private InterstitialAd interstitialAd;
    private const string interstitialUnitId = "ca-app-pub-9999092264265801/2733611959";

    private void Start()
    {
        if (PlayerPrefs.HasKey("ads"))
        {
            ads = PlayerPrefs.GetInt("ads");
        }
    }
    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        if (interstitialAd.IsLoaded() && ads == 0)
        {
            interstitialAd.Show();
        }
    }
}
