using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdManager : MonoSingleton<AdManager>
{
    private BannerView bannerAd;
    private InterstitialAd frontAd;

    // private readonly string appId = "ca-app-pub-5714181718235393~7017903097";
    private readonly string frontAdId = "ca-app-pub-5714181718235393/6271620022";
    private readonly string bennerAdId = "ca-app-pub-5714181718235393/7584701691";

    public override void Init()
    {
        if (this.IsNetworkAvailable())
        {
            // 모바일 광고 SDK를 초기화함.
            MobileAds.Initialize(initStatus => { });

            LoadFrontAd();
            LoadBannerAd();
        }
        else
        {
            Debug.Log("인터넷이 연결되지 않았습니다.");
        }
    }

    private AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region FrontAd

    private void LoadFrontAd()
    {
        AdRequest adRequst = GetAdRequest();

        frontAd = new InterstitialAd(frontAdId);
        frontAd.LoadAd(adRequst);
    }

    public void ShowFrontAd()
    {
        if (frontAd.IsLoaded())
        {
            frontAd.Show();
            LoadFrontAd();
        }
    }

    #endregion

    #region BannerAd

    private void LoadBannerAd()
    {
        if (bannerAd != null)
        {
            bannerAd.Destroy();
        }

        AdRequest adRequst = GetAdRequest();
        AdSize adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerAd = new BannerView(bennerAdId, adSize, AdPosition.Bottom);
        bannerAd.LoadAd(adRequst);
    }

    public void ShowBannerAd()
    {
        bannerAd?.Show();
    }

    public void HideBannerAd()
    {
        bannerAd.Hide();
    }

    #endregion
}
