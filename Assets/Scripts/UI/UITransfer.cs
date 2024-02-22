using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITransfer : UIBase
{
    [SerializeField] private TMP_InputField _inputId;
    [SerializeField] private TMP_InputField _inputMoney;
    [SerializeField] private Button _transferBtn;
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

        _transferBtn.onClick.AddListener(OnTransferBtnClick);
        _transferBtn.onClick.AddListener(ResetAllInputField);
        _backBtn.onClick.AddListener(OnBackBtnClick);
    }

    public void OnTransferBtnClick()
    {
        int transfer;
        UserData otherData;
        UserData myData;

        if(!DataManager.Instance.HasIdInDatas(_inputId.text, out otherData))
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("아이디를 다시 입력해주세요.");
            return;
        }

        if(!int.TryParse(_inputMoney.text, out transfer))
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("잘못된 입력입니다.");
            return;
        }

        myData = MyData.Instance.UserData;

        DataManager.Instance.Transfer(myData, otherData, transfer);
    }

    public void OnBackBtnClick()
    {
        UIManager.Instance.ShowUI<UISelect>();
        Destroy(gameObject);
    }
}
