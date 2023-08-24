using System.Collections;
using System.Collections.Generic;
    
    
    
    using UnityEngine;
    
    public class sendChatGPTkai : MonoBehaviour {

        public string apikey;
        void Start()
    {
        StartCoroutine(ChatCompletionRequest());
    }

    IEnumerator ChatCompletionRequest()
    {
        var chatCompletionAPI = new OpenAIChatCompletionAPI(apikey);

        List<OpenAIChatCompletionAPI.Message> messages = new List<OpenAIChatCompletionAPI.Message>()
        {
            new OpenAIChatCompletionAPI.Message(){role = "system", content = "あなたは優秀なAIアシスタントです。"},
            new OpenAIChatCompletionAPI.Message(){role = "user", content = "今から質問に答えてください"},
        };

        var request = chatCompletionAPI.CreateCompletionRequest(
            new OpenAIChatCompletionAPI.RequestData() { messages = messages }
        );

        yield return request.Send();

        var message = request.Response.choices[0].message;

        Debug.Log(message.content); // 推論された応答
    }
    
    }