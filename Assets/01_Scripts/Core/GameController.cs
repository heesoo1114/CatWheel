using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Subject 
{
    [SerializeField]
    private GameState gameState = GameState.Ready;

    public bool IsReady => gameState == GameState.Ready;
    public bool IsPlaying => gameState == GameState.Playing;
    public bool IsOver => gameState == GameState.Over;
    public bool IsUIMode => gameState == GameState.UIMode;

    private void Start()
    {
        NotifyObservers();
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
        NotifyObservers(); // GameState가 변경된 것을 알려주자
    }

}
