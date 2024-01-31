using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    private GameObject player;
    public GameObject Player => player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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