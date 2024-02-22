using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : UIBase
{
    [SerializeField] private TMP_InputField _inputId;
    [SerializeField] private TMP_InputField _inputPassword;
    [SerializeField] private Button _loginConfirmBtn;
    [SerializeField] private Button _signUpBtn;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _loginConfirmBtn.onClick.AddListener(OnLoginConfirmBtnClick);
        _loginConfirmBtn.onClick.AddListener(ResetAllInputField);
        _signUpBtn.onClick.AddListener(OnSignUpBtnClick);
    }

    private void OnLoginConfirmBtnClick()
    {
        string id = _inputId.text;
        string password = _inputPassword.text;
        DataManager.Instance.Login(id, password);
    }
    
    private void OnSignUpBtnClick()
    {
        UIManager.Instance.ShowUI<UISignUp>();
        Destroy(gameObject);
    }
}
