using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyData : SingletoneBase<MyData>
{
    public UserData UserData {  get; private set; }

    public void SetUserData(UserData userData)
    {
        UserData = userData;
    }
}
