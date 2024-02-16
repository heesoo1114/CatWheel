using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InfoInputScreenUI : ScreenUI
{
    private Transform inputPanelTransform;

    private TMP_InputField infoInput;
    private Button completeButton;

    protected override void Awake()
    {
        base.Awake();

        inputPanelTransform = transform.Find("InputPanel").transform;
        infoInput = inputPanelTransform.Find("InfoInputField").GetComponent<TMP_InputField>();
        completeButton = inputPanelTransform.Find("CompleteButton").GetComponent<Button>();

        // ¿¬°á
        infoInput.onValueChanged.AddListener(CheckInput);
        completeButton.onClick.AddListener(SetNickname);

        completeButton.interactable = false;
    }

    private void CheckInput(string inputText)
    {
        bool isCanUse = (inputText.Length > 0) && (inputText.Length <= 7);
        completeButton.interactable = isCanUse;
    }

    private void SetNickname()
    {
        GameManager.Instance.PlayerData.Name = infoInput.text;
        Hide();
    }

    public override void OnShow()
    {

    }

    public override void OnHide()
    {

    }
}
