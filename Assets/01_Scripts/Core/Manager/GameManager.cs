using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        PoolManager.Instance.Init();
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