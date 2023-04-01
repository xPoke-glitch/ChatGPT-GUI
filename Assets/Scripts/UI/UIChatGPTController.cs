using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AICommand;
using TMPro;

public class UIChatGPTController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private UIChatGPT _uiChatGPT;

    public void SendPrompt()
    {
       _uiChatGPT.EnableSendButton(false);
        string prompt = _uiChatGPT.GetInputFieldPrompt();
        StartCoroutine(OpenAIUtil.InvokeChat(prompt, OnResponseReceived));
    }

    public void OnResponseReceived(string response)
    {
        _uiChatGPT.ResetInputField();
        _uiChatGPT.ShowResponse(response);
        _uiChatGPT.EnableSendButton(true);
    }
}
