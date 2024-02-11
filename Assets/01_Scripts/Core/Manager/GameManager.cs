using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private GameController gameController;

    private GameObject player;
    public GameObject Player => player;

    public StageData StageData { get; private set; }
    public PlayerData PlayerData { get; private set; }

    [SerializeField] private AudioClip clearClip;
    [SerializeField] private AudioClip failClip;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GetComponent<GameController>();

        SetData();
        SetFrameRate();
        Init();
    }

    public override void Init()
    {
        PoolManager.Instance.Init();
        InputHandler.Instance.Init();
        AudioManager.Instance.Init();
        SaveManager.Instance.Init();
        AdManager.Instance.Init();
    }

    public void GameStart()
    {
        gameController.ChangeGameState(GameState.Playing);
    }

    public void GameDone(bool isClear)
    {
        if (isClear)
        {
            gameController.ChangeGameState(GameState.Clear);
            StageData.StageUp();
            AudioManager.Instance.Play(clearClip);
        }
        else
        {
            gameController.ChangeGameState(GameState.Over);
            AudioManager.Instance.Play(failClip);
        }

        StartCoroutine(this.GiveDelayWithAction(0.5f,() =>
        {
            gameController.ChangeGameState(GameState.Ready); 
        }));
    }

    public void FinishGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }

    public void SetData()
    {
        StageData = SaveManager.Instance.LoadData<StageData>();
        PlayerData = SaveManager.Instance.LoadData<PlayerData>();
    }

    private void OnApplicationQuit()
    {
        SaveManager.Instance.SaveData(StageData);
        PlayerData.isMuted = AudioManager.Instance.IsMuted;
        SaveManager.Instance.SaveData(PlayerData);
    }

    private void SetFrameRate()
    {
#if UNITY_ANDROID
        Application.targetFrameRate = 60;
#endif
    }
}