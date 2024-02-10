using UnityEngine.UI;
using UnityEngine;

public class MainScreenUI : ScreenUI
{
    private Button playButton;
    private Button soundButton;
    private Button rankingButton;
    private Button exitButton;

    private Image soundIconImage;
    [SerializeField] private Sprite audioPlayImage;
    [SerializeField] private Sprite audioMuteImage;

    protected override void Awake()
    {
        base.Awake();

        Transform buttonPanel = transform.Find("ButtonPanel").transform;
        playButton = transform.Find("PlayButton").GetComponent<Button>();
        soundButton = buttonPanel.Find("SoundButton").GetComponent<Button>();
        soundIconImage = soundButton.transform.Find("Icon").GetComponent<Image>();
        rankingButton = buttonPanel.Find("RankingButton").GetComponent<Button>();
        exitButton = buttonPanel.Find("ExitButton").GetComponent<Button>();

        playButton.onClick.AddListener(GameManager.Instance.GameStart);
        soundButton.onClick.AddListener(OnSoundButtonClick);
        rankingButton.onClick.AddListener(() => Debug.Log("rankingButton"));
        exitButton.onClick.AddListener(GameManager.Instance.FinishGame);
    }

    private void OnSoundButtonClick()
    {
        AudioManager.Instance.VolumeChange();
        if (AudioManager.Instance.IsMuted)
        {
            soundIconImage.sprite = audioMuteImage;
        }
        else
        {
            soundIconImage.sprite = audioPlayImage;
        }
    }

    public override void OnShow()
    {
        if (AudioManager.Instance.IsMuted)
        {
            soundIconImage.sprite = audioMuteImage;
        }
        else
        {
            soundIconImage.sprite = audioPlayImage;
        }
    }

    public override void OnHide()
    {
        
    }
}
