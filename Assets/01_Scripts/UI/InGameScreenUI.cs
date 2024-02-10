using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InGameScreenUI : ScreenUI
{
    private StageData stageData;
    private Transform playerTransform;

    private Slider distanceSlider;
    private TextMeshProUGUI stageText;

    private float goalLinePositionX = 300;
    private float toMaxValuePercent;

    protected override void Awake()
    {
        base.Awake();
        stageText = transform.Find("StageText").GetComponent<TextMeshProUGUI>();
        distanceSlider = GetComponentInChildren<Slider>();

        toMaxValuePercent = distanceSlider.maxValue / goalLinePositionX;
    }

    private void Update()
    {
        if (IsActive)
        {
            float passedDistance = playerTransform.position.x * toMaxValuePercent;  
            distanceSlider.value = passedDistance;
        }
    }

    public override void OnShow()
    {
        stageData = GameManager.Instance.StageData;
        playerTransform = GameManager.Instance.Player.transform;

        stageText.text = $"스테이지 {stageData.StageNumber}";
    }

    public override void OnHide()
    {
        distanceSlider.value = 0;
    }
}
