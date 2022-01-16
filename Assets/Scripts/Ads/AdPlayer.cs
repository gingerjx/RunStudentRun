using UnityEngine;
using UnityEngine.Advertisements;
using System.Linq;
using System.Collections.Generic;

public class AdPlayer : MonoBehaviour
{
    public void PlayAd()
    {
        BackgroundMusicHandler.AdsNowPlaying = true;
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleResult };
            Advertisement.Show("Interstitial_Android", options);
        }
    }

    public void PlayRewardedAd()
    {
        BackgroundMusicHandler.AdsNowPlaying = true;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleResult };
            Advertisement.Show("Rewarded_Android", options);
        }
    }

    public void PlayRewardedAdWithCallback()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            ShowOptions options = new ShowOptions { resultCallback = handleResultWithCallback };
            Advertisement.Show("Rewarded_Android", options);
        }
    }

    private void handleResultWithCallback(ShowResult result) {
        LootBoxHandler lootBoxHandler = GameObject.Find("LootBoxHandler").GetComponent<LootBoxHandler>();

        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                Time.timeScale = 1;
                lootBoxHandler.drawCallback(1);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                Time.timeScale = 1;
                lootBoxHandler.drawCallback(1);
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                Time.timeScale = 1;
                break;
        }
    }

    private void HandleResult(ShowResult result)
    {
        GameObject.Find("MainMenuBackgroundMusic").GetComponent<AudioSource>().Stop();
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                Time.timeScale = 1;
                BackgroundMusicHandler.AdsNowPlaying = false;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                Time.timeScale = 1;
                BackgroundMusicHandler.AdsNowPlaying = false;
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                Time.timeScale = 1;
                BackgroundMusicHandler.AdsNowPlaying = false;
                break;
        }
        GameObject.Find("MainMenuBackgroundMusic").GetComponent<AudioSource>().Play();
        BackgroundMusicHandler.AdsNowPlaying = false;
    }
}