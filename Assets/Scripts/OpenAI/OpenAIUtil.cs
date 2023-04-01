using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System;
using System.Collections;

namespace AICommand {

public static class OpenAIUtil
{
        public static string CreateChatRequestBody(string prompt)
        {
            var msg = new OpenAI.RequestMessage();
            msg.role = "user";
            msg.content = prompt;

            var req = new OpenAI.Request();
            req.model = "gpt-3.5-turbo";
            req.messages = new[] { msg };

            return JsonUtility.ToJson(req);
        }

        public static IEnumerator InvokeChat(string prompt, Action<string> OnResponseReceived)
        {
            var settings = AICommandSettings.instance;

            // POST
            using var post = UnityWebRequest.Post
              (OpenAI.Api.Url, CreateChatRequestBody(prompt), "application/json");

            // Request timeout setting
            post.timeout = settings.timeout;

            // API key authorization
            post.SetRequestHeader("Authorization", "Bearer " + settings.apiKey);

            // Request start
            var req = post.SendWebRequest();

            // Waiting for the response
            yield return req;

            // Response extraction
            var json = post.downloadHandler.text;
            Debug.Log(json);
            var data = JsonUtility.FromJson<OpenAI.Response>(json);

            // Callback
            OnResponseReceived?.Invoke(data.choices[0].message.content);
        }
    }

}
