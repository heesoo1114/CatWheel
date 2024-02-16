using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class RankingScreenUI : ScreenUI
{
    private Transform rankingPanelTransform;
    private Transform rankingsTransform;

    private GameObject noticeText;

    private Button closeButton;

    private List<UserData> userDatas = new ();

    private readonly int rankingShowIndex = 10;

    protected override void Awake()
    {
        base.Awake();

        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        noticeText = GameObject.Find("NoticeText");
        rankingPanelTransform = transform.Find("RankingPanel").transform;
        rankingsTransform = rankingPanelTransform.Find("Rankings").transform;

        // 연결
        closeButton.onClick.AddListener(Hide);
    }

    private IEnumerator UpdateUI()
    {
        yield return new WaitUntil(() => UserManager.Instance.IsLoaded);
        noticeText.SetActive(false);

        userDatas = UserManager.Instance.UserDatas;
        userDatas.Reverse(); // 점수기준 내림차순으로
        userDatas.RemoveRange(rankingShowIndex, userDatas.Count - rankingShowIndex);

        for (int i = 0; i < rankingShowIndex; i++)
        {
            UserInfoText infoText = PoolManager.Instance.Pop("UserInfoText") as UserInfoText;
            infoText.transform.SetParent(rankingsTransform);
            infoText.transform.localScale = Vector3.one;
            infoText.SetText(i + 1, userDatas[i]);
        }
    }

    public override void OnShow()
    {
        UserManager.Instance.ReadUser();
        StartCoroutine(UpdateUI());
    }

    public override void OnHide()
    {
        UserInfoText[] infoTexts = rankingsTransform.GetComponentsInChildren<UserInfoText>();
        foreach (UserInfoText text in infoTexts)
        {
            PoolManager.Instance.Push(text);
        }

        noticeText.SetActive(true);
    }
}
