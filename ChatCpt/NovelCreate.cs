using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using UnityEditor;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

public class NovelCreate : MonoBehaviour
{
    public List<ChatCharactor> ChatCharactors;
    public Field field;
    public SendChatGPT SendChatGPT;
    public ChatExecute ChatExecute;
    public string[] Serifs;
    public int MoziCount;



    public Dictionary<string, string> Story =new Dictionary<string, string>();
    
public async void Start() {
    ChatExecute.ChatData=await CreateChatData();
    #if UNITY_EDITOR
    EditorUtility.SetDirty(ChatExecute.ChatData);
AssetDatabase.SaveAssets();
#endif

ChatExecute.Play();
}

  
    public async UniTask<ChatData> CreateChatData()
    {
        string prompt = "";
        foreach (var item in ChatCharactors)
        {
            prompt += (item.name + "と");
        }
        prompt+= "の会話を作って。舞台は"+field.name+"状況説明文も入れること 長さは"+MoziCount.ToString()+"文字くらいで";
      
        var text = await SendChatGPT.Get(prompt);
        Serifs = text.Split("\n\n");

        foreach (string Serif in Serifs)
        {if (Serif.Contains("："))
        {
            string[] arr = Serif.Split("：");
            Story.Add(arr[1], arr[0]);
        }else
        {
             Story.Add(Serif, "状況解説");
        }
        }


      phases=new List<phase>();
        foreach (var item in Story)
        {
          phase phase=new phase();
          phase.message =item.Key;
           phase.ChatCharactor = GetChatCharactor(item.Value);
            phases.Add(phase);
        }

        ChatData ChatData = ScriptableGenerator.CreateScriptableObject<ChatData>();
        ChatData.phases=phases;
        return ChatData;
    }

  public List<phase> phases;

    public ChatCharactor GetChatCharactor(string name)
    {
        foreach (var item in ChatCharactors)
        {
            if (name.Contains(item.name))
            {
                   return item;
            } 
         
        }
        return null;
    }
}
