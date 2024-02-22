using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : UIBase
{
    [SerializeField] private TextMeshProUGUI _popupText;
    [SerializeField] private Button _confirmBtn;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _confirmBtn.onClick.AddListener(OnConfirmBtnClick);
    }

    public void SetPopupText(string text)
    {
        _popupText.text = text;
    }

    private void OnConfirmBtnClick()
    {
        Destroy(gameObject);
    }
}
