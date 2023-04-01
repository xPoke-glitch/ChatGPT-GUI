using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIChatGPT : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private TMP_InputField _inputFieldPrompt;
    [SerializeField]
    private TextMeshProUGUI _resultText;
    [SerializeField]
    private Button _sendButton;

    public void EnableSendButton(bool enable)
    {
        _sendButton.enabled = enable;
    }

    public void ResetInputField()
    {
        _inputFieldPrompt.text = "";
    }

    public void ShowResponse(string response)
    {
        _resultText.text = response;
    }

    public string GetInputFieldPrompt() => _inputFieldPrompt.text;
}
