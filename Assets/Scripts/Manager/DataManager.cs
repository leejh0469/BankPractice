using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DataManager : SingletoneBase<DataManager>  
{

    private UserDatas userDatas;

    public Action OnBalanceChanged;

    // Start is called before the first frame update
    void Awake()
    {
        userDatas = UserDAO.Instance.LoadUserData();
    }

    public void Login(string id, string password)
    {
        UserData userData = null;
        
        HasIdInDatas(id, out userData);

        if(userData == null)
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("사용자의 아이디와 일치하는 아이디가 없습니다.");
            return;
        }

        if(userData.password != password)
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("비밀번호가 일치하지 않습니다.");
            return;
        }

        MyData.Instance.SetUserData(userData);
        SceneManager.LoadScene("MainScene");
    }

    public void SignUp(string id, string password, string passwordConfirm, string name)
    {
        if (HasIdInDatas(id, out UserData data))
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("아이디가 이미 존재합니다.");
            return;
        }


        UserData userData = new UserData(id, password, name, 0);

        userDatas.list.Add(userData);
    }
    public bool HasIdInDatas(string id, out UserData userData)
    {
        foreach (var data in userDatas.list)
        {
            if (data.id == id)
            {
                userData = data;
                return true;
            }
        }
        userData = null;
        return false;
    }

    public void Deposit(UserData userData, int money)
    {
        userData.balance += money;
        OnBalanceChanged?.Invoke();
    }

    public void WithDraw(UserData userData, int money)
    {
        if (money > userData.balance)
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("자금 부족");
            return;
        }
        userData.balance -= money;
        OnBalanceChanged?.Invoke();
    }

    public void Transfer(UserData myData, UserData otherData, int money)
    {
        if (money > myData.balance)
        {
            UIPopup popup = UIManager.Instance.ShowUI<UIPopup>();
            popup.SetPopupText("자금 부족");
            return;
        }

        myData.balance -= money;
        otherData.balance += money;

        OnBalanceChanged?.Invoke();
    }

    private void OnApplicationQuit()
    {
        UserDAO.Instance.SaveUserData(userDatas);
    }

}
