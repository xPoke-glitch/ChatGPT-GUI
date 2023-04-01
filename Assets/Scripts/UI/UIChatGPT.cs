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
    [SerializeField]
    private GameObject _loadingIcon;

    public void ShowLoadingIcon(bool show)
    {
        _loadingIcon.SetActive(show);
    }

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
        _resultText.text = "";
        StopAllCoroutines();
        StartCoroutine(ShowResponseTextAnimated(response, 0.02f));
    }

    public string GetInputFieldPrompt() => _inputFieldPrompt.text;

    private IEnumerator ShowResponseTextAnimated(string response, float betweenTime)
    {
        for (int i = 0; i < response.Length; i++)
        {
            _resultText.text = string.Concat(_resultText.text, response[i]);
            yield return new WaitForSeconds(betweenTime);
        }
    }
}
