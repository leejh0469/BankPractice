using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMain : UIBase
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI balanceText;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        DataManager.Instance.OnBalanceChanged += SetBalanceText;

        SetBalanceText();
        SetNameText();
    }

    public void SetBalanceText()
    {
        balanceText.text = MyData.Instance.UserData.balance.ToString();
    }

    public void SetNameText()
    {
        nameText.text = MyData.Instance.UserData.name;
    }
}
