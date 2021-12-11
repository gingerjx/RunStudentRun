using UnityEngine;
using UnityEngine.Advertisements;

public class AdPlayer : MonoBehaviour
{
    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleResult };
            Advertisement.Show("Rewarded_Android", options);
        }
    }

    private void HandleResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                Time.timeScale = 1;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                Time.timeScale = 1;
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                Time.timeScale = 1;
                break;
        }
    }
}