using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private GameController gameController;

    private GameObject player;
    public GameObject Player => player;

    private string dataSaveKey = "stageData";
    public StageData StageData { get; private set; }

    [SerializeField] private AudioClip clearClip;
    [SerializeField] private AudioClip failClip;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GetComponent<GameController>();
        StageData = new StageData();

        SetFrameRate();
        Init();
    }

    public override void Init()
    {
        PoolManager.Instance.Init();
        InputHandler.Instance.Init();
        AudioManager.Instance.Init();
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

    private void SetFrameRate()
    {
#if UNITY_ANDROID
        Application.targetFrameRate = 60;
#endif
    }

    #region SaveSystem

    private void SaveStageData()
    {
        string json = JsonUtility.ToJson(StageData);
        PlayerPrefs.SetString(dataSaveKey, json);
        PlayerPrefs.Save();
    }

    private void LoadStageData()
    {
        if (PlayerPrefs.HasKey(dataSaveKey))
        {
            string json = PlayerPrefs.GetString(dataSaveKey);
            StageData = JsonUtility.FromJson<StageData>(json);
            Debug.Log(json);
        }
        else
        {
            SaveStageData();
        }
    }

    private void OnEnable()
    {
        LoadStageData();
    }

    private void OnDisable()
    {
        SaveStageData();
    }

    #endregion
}