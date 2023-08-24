using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using Cysharp.Threading.Tasks;

using Newtonsoft.Json;


public class SendChatGPT: MonoBehaviour
{
    /// <summary>
    /// APIエンドポイント
    /// </summary>
    const string API_END_POINT = "https://api.openai.com/v1/completions";
    /// <summary>
    [Header("API KEY")] 
    public string API_KEY = "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";
    /// <summary>
    /// 入力欄
    /// </summary>
    [SerializeField] 
    private InputField Input;
    [SerializeField]
    private Text Output;

    [SerializeField]
    private Button ExecButton;
    [SerializeField] 
    private Button QuitButton;


public async UniTask<string> Get(string st){
    
            if (!string.IsNullOrEmpty(st))
            {
                //レスポンス取得
                var response = await GetAPIResponse(st) ;
                //レスポンスからテキスト取得
                string outputText = response.Choices.FirstOrDefault().Text;
                return outputText.TrimStart('\n');
            }
            return "";

}
    private void Start()
    {
        // API実行ボタン
        ExecButton.onClick.AddListener(async ()=>Output.text=await Get(Input.text));
        // 終了ボタン
        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
 /// <summary>
    /// APIからレスポンス取得
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async UniTask<APIResponseData> GetAPIResponse(string prompt)
    {
        APIRequestData requestData = new()
        {
            Prompt = prompt,
            MaxTokens = 300 //レスポンスのテキストが途切れる場合、こちらを変更する
        };

        string requestJson = JsonConvert.SerializeObject(requestData, Formatting.Indented);
        Debug.Log(requestJson);

        // POSTするデータ
        byte[] data = System.Text.Encoding.UTF8.GetBytes(requestJson);


        string jsonString = null;
        // POSTリクエストを送信
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(API_END_POINT, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(data);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + API_KEY);
            await request.SendWebRequest();

            switch (request.result)
            {
                case UnityWebRequest.Result.InProgress:
                    Debug.Log("リクエスト中");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("リクエスト成功");
                    jsonString = request.downloadHandler.text;
                    // レスポンスデータを表示
                    Debug.Log(jsonString);
                    break;
                default: 
                    throw new ArgumentOutOfRangeException();

            }
        }

        // デシリアライズ
        APIResponseData jsonObject = JsonConvert.DeserializeObject<APIResponseData>(jsonString);

        return jsonObject;
    }
}

/// <summary>
/// APIリクエスト
/// 
/// https://beta.openai.com/docs/api-reference/authentication
/// </summary>

[JsonObject]
public class APIRequestData
{
    [JsonProperty("model")]
    public string Model { get; set; } = "text-davinci-003";
    [JsonProperty("prompt")]
    public string Prompt { get; set; } = "";
    [JsonProperty("temperature")]
    public int Temperature { get; set; } = 0;
    [JsonProperty("max_tokens")]
    public int MaxTokens { get; set; } = 100;
}

/// <summary>
/// APIレスポンス
/// 
/// https://beta.openai.com/docs/api-reference/authentication
/// </summary>
[JsonObject]
public class APIResponseData
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("object")]
    public string Object { get; set; }
    [JsonProperty("model")]
    public string Model { get; set; }
    [JsonProperty("created")]
    public int Created { get; set; }
    [JsonProperty("choices")]
    public ChoiceData[] Choices { get; set; }
    [JsonProperty("usage")]
    public UsageData Usage { get; set; }
}

[JsonObject]
public class UsageData
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens { get; set; }
    [JsonProperty("completion_tokens")]
    public int CompletionTokens { get; set; }
    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }
}

[JsonObject]
public class ChoiceData
{
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("index")]
    public int Index { get; set; }
    [JsonProperty("logprobs")]
    public string Logprobs { get; set; }
    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }
}