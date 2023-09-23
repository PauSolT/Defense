using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameId;
    public string iosGameId;

    public bool isTestingMode = true;

    string gameId;

    private void Awake()
    {
        InitializeAds();
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialized ads");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Not Initialized ads");
    }

    void InitializeAds()
    {

#if UNITY_IOS
        gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
        gameId = androidGameId;
#endif

        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this);
        }
    }

}
