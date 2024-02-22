using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : UIBase
{
    [SerializeField] private Button _depositBtn;
    [SerializeField] private Button _withdrawBtn;
    [SerializeField] private Button _transferBtn;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        _depositBtn.onClick.AddListener(OnDepositBtnClick);
        _withdrawBtn.onClick.AddListener(OnWithdrawBtnClick);
        _transferBtn.onClick.AddListener(OnTransferBtnClick);
    }

    public void OnDepositBtnClick()
    {
        UIManager.Instance.ShowUI<UIDeposit>();
        Destroy(gameObject);
    }

    public void OnWithdrawBtnClick()
    {
        UIManager.Instance.ShowUI<UIWithdraw>();
        Destroy(gameObject);
    }

    public void OnTransferBtnClick()
    {
        UIManager.Instance.ShowUI<UITransfer>();
        Destroy(gameObject);
    }
}
