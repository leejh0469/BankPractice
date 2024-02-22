using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string id;
    public string password;
    public string name;
    public int balance;

    public UserData(string id, string password, string name, int balance)
    {
        this.id = id;
        this.password = password;
        this.name = name;
        this.balance = balance;
    }
}

public class UserDatas
{
    public List<UserData> list;
}
