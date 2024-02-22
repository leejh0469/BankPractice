using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.ShowUI<UIMain>();
        UIManager.Instance.ShowUI<UISelect>();
    }
}
