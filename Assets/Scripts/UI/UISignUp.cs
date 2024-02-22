using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISignUp : UIBase
{
    [SerializeField] private TMP_InputField _inputId;
    [SerializeField] private TMP_InputField _inputPassword;
    [SerializeField] private TMP_InputField _inputPasswordConfirm;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private Button _signUpBtn;
    [SerializeField] private Button _backBtn;

    // Start is called before the first frame update
    void Start()
    {
        _signUpBtn.onClick.AddListener(OnSignUpBtnClick);
        _backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnSignUpBtnClick()
    {
        string id = _inputId.text;
        string password = _inputPassword.text;
        string passwordConfirm = _inputPasswordConfirm.text;
        string name = _inputName.text;

        DataManager.Instance.SignUp(id, password, passwordConfirm, name);
    }

    private void OnBackBtnClick()
    {
        UIManager.Instance.ShowUI<UILogin>();
        Destroy(gameObject);
    }
}
