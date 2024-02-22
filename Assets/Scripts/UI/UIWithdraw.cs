using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWithdraw : UIBase
{
    [SerializeField] private TMP_InputField _inputMoney;
    [SerializeField] private Button _withdrawBtn;
    [SerializeField] private Button _backBtn;

    private UIMain uiMain;

    private void Awake()
    {
        uiMain = GameObject.FindObjectOfType<UIMain>();
    }

    public override void Start()
    {
        base.Start();

        _withdrawBtn.onClick.AddListener(OnWithdrawBtnClick);
        _withdrawBtn.onClick.AddListener(ResetAllInputField);
        _backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnWithdrawBtnClick()
    {
        int withdrawMoney;

        if(!int.TryParse(_inputMoney.text, out withdrawMoney))
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("잘못된 입력입니다.");
            return;
        }

        UserData userData = MyData.Instance.UserData;

        DataManager.Instance.WithDraw(userData, withdrawMoney);
    }

    private void OnBackBtnClick()
    {
        UIManager.Instance.ShowUI<UISelect>();
        Destroy(gameObject);
    }
}
