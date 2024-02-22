using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset font;

    public virtual void Start()
    {
        TextMeshProUGUI[] texts;

        texts = GetComponentsInChildren<TextMeshProUGUI>();

        foreach(var text in texts)
        {
            text.font = font;
        }

        Debug.Log("hi");
    }

    public void ResetAllInputField()
    {
        TMP_InputField[] inputs;

        inputs = GetComponentsInChildren<TMP_InputField>();

        foreach(var input in inputs)
        {
            input.text = "";
        }
    }
}