using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDeposit : UIBase
{
    [SerializeField] private TMP_InputField _inputMoney;
    [SerializeField] private Button _depositBtn;
    [SerializeField] private Button _backBtn;

    private UIMain uiMain;

    private void Awake()
    {
        uiMain = GameObject.FindObjectOfType<UIMain>();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();



        _depositBtn.onClick.AddListener(OnDepositBtnClick);
        _depositBtn.onClick.AddListener(ResetAllInputField);
        _backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnDepositBtnClick()
    {
        int depositMoney;

        if(!int.TryParse(_inputMoney.text, out depositMoney))
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("잘못된 입력입니다.");
            return;
        }

        DataManager.Instance.Deposit(MyData.Instance.UserData, depositMoney);
    }

    private void OnBackBtnClick()
    {
        UIManager.Instance.ShowUI<UISelect>();
        Destroy(gameObject);
    }
}
