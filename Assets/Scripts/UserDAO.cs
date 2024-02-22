using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserDAO : SingletoneBase<UserDAO>
{
    private string pathString = "UserData.json";
    private string path;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, pathString);
        Debug.Log("DAO");
    }

    public void SaveUserData(UserDatas userDatas)
    {
        string jsonData = JsonUtility.ToJson(userDatas, true);

        File.WriteAllText(path, jsonData);
    }

    public UserDatas LoadUserData()
    {
        Debug.Log("df");
        if (!File.Exists(path))
        {
            UserDatas userDatas = new UserDatas();
            userDatas.list = new List<UserData>();
            return userDatas;
        }

        string jsonData = File.ReadAllText(path);

        return JsonUtility.FromJson<UserDatas>(jsonData);
    }
}
