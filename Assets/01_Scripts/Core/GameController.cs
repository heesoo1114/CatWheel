using UnityEngine;

public class GameController : Subject 
{
    [SerializeField]
    private GameState gameState = GameState.Ready;

    public bool IsReady => gameState == GameState.Ready;
    public bool IsPlaying => gameState == GameState.Playing;
    public bool IsClear => gameState == GameState.Clear;
    public bool IsOver => gameState == GameState.Over;

    private void Start()
    {
        NotifyObservers();
    }

    public void ChangeGameState(GameState state)
    {
        if (state != gameState)
        {
            gameState = state;
        }

        NotifyObservers(); // GameState가 변경된 것을 알려주자
    }
}
