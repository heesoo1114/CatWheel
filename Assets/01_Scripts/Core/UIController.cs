using System.Collections.Generic;

public class UIController : Observer<GameController>
{
    private List<ScreenUI> screens = new ();

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

    private void Start()
    {
        
    }

    private void ClearSreen()
    {
        foreach (ScreenUI screen in screens)
        {
            screen.Hide();
        }
    }

    private void OnReady()
    {
        ScreenUI currentScreen = PoolManager.Instance.Pop("MainScreen") as ScreenUI;
        currentScreen.Show();
        screens.Add(currentScreen);
    }

    private void OnPlaying()
    {
        ClearSreen();
        ScreenUI currentScreen = PoolManager.Instance.Pop("InGameScreen") as ScreenUI;
        currentScreen.Show();
        screens.Add(currentScreen);
    }

    private void OnFinish()
    {
        ClearSreen();

        // coverScreen은 애니메이션 재생이 끝나면 자동으로 사라짐
        ScreenUI currentScreen = PoolManager.Instance.Pop("CoverScreen") as ScreenUI;
        currentScreen.Show();

        StartCoroutine(this.GiveDelayWithAction(1.1f, () =>
        {
            currentScreen.Hide();
        }));
    }
}
