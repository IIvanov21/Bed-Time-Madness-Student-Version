using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour,IUnityAdsListener,IUnityAdsInitializationListener
{
    [SerializeField] string androidGameId;//Android
    [SerializeField] string iOSGameId;//iOS
    [SerializeField] bool testMode = true;//Simple bool to switch between test and release mode
    string adId = null; //Capture the adId that connects back to the Unity Services and makes us money

    void Awake()
    {
        CheckPlatform();
    }

    void CheckPlatform()
    {
        string gameId = null;
        #if UNITY_IOS || UNITY_EDITOR
        {
            gameId = iOSGameId;
            adId = "Rewarded_iOS";
        }
#elif UNITY_ANDROID || UNITY_EDITOR
        {
            gameId=androidGameId;
            adId = "Rewarded_Android";
        }
#endif
        Advertisement.Initialize(gameId, testMode, false, this);
    }

    IEnumerator WaitForAd()
    {
        while (!Advertisement.isInitialized)
        {
            yield return null;
        }

        LoadAd();
    }

    void LoadAd()
    {
        Advertisement.AddListener(this);
        Advertisement.Load(adId);
    }

    public void WatchAd()
    {
        Advertisement.Show(adId);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initilization Failed: {error.ToString()} - {message}");
        //Debug.Log("Unity Ads Initilization Failed: " + error.ToString() + " - " + message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //Reward the player
            Debug.Log("Unity Ads reward completed!");
        }
        else if (showResult == ShowResult.Skipped)
        {
            //Dont reward the player
            Debug.Log("Player has skipped the ad!");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }

        Advertisement.Load(placementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }
}
