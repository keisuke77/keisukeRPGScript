using UnityEngine;
using UnityEngine.Networking;

public class tweet : MonoBehaviour
{


    public int clickflag;

    public string urls;
    public string text;
    public string hashtag;
    public void OnClickTwitterButton()
{
    //urlの作成
    string esctext = UnityWebRequest.EscapeURL(text+"\n"+urls);
    string esctag = UnityWebRequest.EscapeURL(hashtag);
    string url = "https://twitter.com/intent/tweet?text=" + esctext + "&hashtags=" + esctag;

    //Twitter投稿画面の起動
    Application.OpenURL(url);

    //ここに報酬の処理を記載
    clickflag = 1;
}
}