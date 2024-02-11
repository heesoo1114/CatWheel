public class AdController : Observer<GameController>
{
    private void Awake()
    {
        SetUp();
    }

    public override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            AdManager.Instance.ShowBannerAd();
        }
        else
        {
            AdManager.Instance.HideBannerAd();
        }

        if (mySubject.IsClear)
        {
            AdManager.Instance.ShowFrontAd();
        }
    }
}
