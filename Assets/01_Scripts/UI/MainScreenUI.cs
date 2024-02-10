using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MainScreenUI : ScreenUI
{
    private Button playButton;
    private Button soundButton;
    private Button rankingButton;
    private Button exitButton;

    protected override void Awake()
    {
        base.Awake();

        Transform buttonPanel = transform.Find("ButtonPanel").transform;
        playButton = transform.Find("PlayButton").GetComponent<Button>();
        soundButton = buttonPanel.Find("SoundButton").GetComponent<Button>();
        rankingButton = buttonPanel.Find("RankingButton").GetComponent<Button>();
        exitButton = buttonPanel.Find("ExitButton").GetComponent<Button>();

        playButton.onClick.AddListener(() => GameManager.Instance.GameStart());
        soundButton.onClick.AddListener(() => Debug.Log("soundButton"));
        rankingButton.onClick.AddListener(() => Debug.Log("rankingButton"));
        exitButton.onClick.AddListener(() => GameManager.Instance.FinishGame());
    }

    public override void OnShow()
    {
        

    }

    public override void OnHide()
    {
        
    }
}
