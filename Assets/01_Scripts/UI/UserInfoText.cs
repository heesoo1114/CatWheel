using TMPro;

public class UserInfoText : PoolableMono
{
    private TextMeshProUGUI indexText;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        indexText = transform.Find("Index").GetComponent<TextMeshProUGUI>();
        nameText = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    public void SetText(int rankingIndex, UserData data)
    {
        indexText.text = rankingIndex.ToString();
        nameText.text = data.Name;
        scoreText.text = data.Score.ToString();
    }

    public override void OnPop()
    {

    }

    public override void OnPush()
    {

    }
}
