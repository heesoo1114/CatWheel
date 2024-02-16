using System.Collections.Generic;
using System.Diagnostics;
using static UnityEngine.ParticleSystem;

public class UIController : Observer<GameController>
{
    private List<ScreenUI> screens = new ();

    private string coverScreenString = "CoverScreen";
    private string mainScreenString = "MainScreen";
    private string inGameScreenString = "InGameScreen";
    private string rankingScreenString = "RankingScreen";
    private string infoInputScreenString = "InfoInputScreen";

    public override void Notify()
    {
        if (mySubject.IsReady)
        {
            OnReady();
        }
        else if (mySubject.IsPlaying)
        {
            OnPlaying();
        }
        else
        {
            OnFinish();
        }
    }

    private void Awake()
    {
        SetUp();
    }

    private void ClearSreen()
    {
        foreach (ScreenUI screen in screens)
        {
            screen.Hide();
        }
        screens.Clear();
    }

    private void OnReady()
    {
        ClearSreen();

        if (GameManager.Instance.PlayerData.Name == "Guest")
        {
            var infoInputScreen = GetScreenUI(infoInputScreenString);
            infoInputScreen.Show();
        }

        var mainScreen = GetScreenUI(mainScreenString) as MainScreenUI;
        if (mainScreen != null)
        {
            mainScreen.OnRankigButtonClick += (() =>
            {
                var rankingScreen = GetScreenUI(rankingScreenString);
                rankingScreen.Show();
            });
            mainScreen.Show();
            mainScreen.transform.SetAsFirstSibling();
        }
    }

    private void OnPlaying()
    {
        ClearSreen();

        var inGameScreen = GetScreenUI(inGameScreenString);
        inGameScreen.Show();
    }

    private void OnFinish()
    {
        var coverScreen = GetScreenUI(coverScreenString, true);
        coverScreen.Show();

        // coverScreen은 애니메이션 재생이 끝나면 자동으로 사라지게
        StartCoroutine(this.GiveDelayWithAction(1.2f, () =>
        {
            coverScreen.Hide();
        }));
    }
    
    private ScreenUI GetScreenUI(string poolID, bool isAutoDelete = false)
    {
        var screen = PoolManager.Instance.Pop(poolID) as ScreenUI;

        if (false == isAutoDelete)
        {
            screens.Add(screen);
        }
        return screen;
    }
}
