using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private GameController gameController;

    private GameObject player;
    public GameObject Player => player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GetComponent<GameController>();

        Init();
    }

    private void Start()
    {
        GameStart();
    }

    public override void Init()
    {
        PoolManager.Instance.Init();
        InputHandler.Instance.Init();
    }

    public void GameStart()
    {
        gameController.ChangeGameState(GameState.Playing);
        InputHandler.Instance.ActivateReciever();
    }

    public void GameDone(bool isClear)
    {
        if (isClear)
        {
            gameController.ChangeGameState(GameState.Clear);
        }
        else
        {
            gameController.ChangeGameState(GameState.Over);
        }

        InputHandler.Instance.DeactivateReciever();

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
}