

 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
 
using UnityEngine.Events;
public class message : MonoBehaviour {
public static UnityEvent events;
    //　メッセージUI
    public Text messageText;
     public string url="https://cdn.wikiwiki.jp/to/w/oni_giri/%E3%82%B2%E3%83%BC%E3%83%A0%E3%82%AC%E3%82%A4%E3%83%89/%E6%93%8D%E4%BD%9C%E6%96%B9%E6%B3%95/::ref/gamepad.jpg?rev=fe31d4835c1857d02d1dbb4fdf96a13b&t=20131207195601";
    
    public RawImage Images;


      public delegate void OnCompleteDelegate();

    //　表示するメッセージ
    [SerializeField]
    [TextArea(1, 20)]
    private string allMessage = "今回はRPGでよく使われるメッセージ表示機能を作りたいと思います。\n"
            + "メッセージが表示されるスピードの調節も可能であり、改行にも対応します。\n"
            + "改善の余地がかなりありますが、               最低限の機能は備えていると思われます。\n"
            + "ぜひ活用してみてください。\n<>"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ<>"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ<>"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ";
    //　使用する分割文字列
    [SerializeField]
    private string splitString = "<>";
    //　分割したメッセージ
    private string[] splitMessage;
    //　分割したメッセージの何番目か
    private int messageNum;
    public System.Action action;
    public bool onstart;
    //　テキストスピード
    [SerializeField]
    private float textSpeed = 0.05f;
    //　経過時間
    private float elapsedTime = 0f;
    //　今見ている文字番号
    private int nowTextNum = 0;
    //　マウスクリックを促すアイコン
    public Image clickIcon;    public Canvas messagecanvas;
    public bool auto;
    public Image icon;
    public Transform tr1;public Transform tr2;public Transform tr3;
    //　クリックアイコンの点滅秒数
    [SerializeField]
    private float clickFlashTime = 0.2f;
    //　1回分のメッセージを表示したかどうか
    public bool isOneMessage = false;
    //　メッセージをすべて表示したかどうか
    public bool isEndMessage = true;
     float autotime;
 public float cameradistance;
    void Awake() {
         gameObject.pclass().message=this;
        clickIcon.enabled = false;
         messageText.text = "";
          messagecanvas.enabled=false; 
          keikei.allMessage=Object.FindObjectsOfType(typeof(message))as message[];
         
            
       }



       void LateStart()
       {    if (onstart)
           {
               SetMessagePanel(allMessage);
           } 
        
       }
 public void extends(){

     
if (splitMessage[messageNum][nowTextNum].ToString()=="u"&&splitMessage[messageNum][nowTextNum+1].ToString()=="r"&&splitMessage[messageNum][nowTextNum+2].ToString()=="l")
  {
StartCoroutine(keikei.GetImageFromURL(url,Images));
nowTextNum=nowTextNum+3;
  }

if (splitMessage[messageNum][nowTextNum].ToString()=="t"&&splitMessage[messageNum][nowTextNum+1].ToString()=="r")
 {if (splitMessage[messageNum][nowTextNum+2].ToString()=="0")
     {

gameObject.pclass().AutoRotateCamera.atractend();
         nowTextNum=nowTextNum+3;
  
     }
     if (splitMessage[messageNum][nowTextNum+2].ToString()=="1")
     {
if (tr1)
{
    
gameObject.pclass().AutoRotateCamera.lerpatractcamera(tr1,cameradistance==0?-9.8f:cameradistance);
}
         nowTextNum=nowTextNum+3;
  
     }
     if (splitMessage[messageNum][nowTextNum+2].ToString()=="2")
     {

if (tr2)
{
    
gameObject.pclass().AutoRotateCamera.lerpatractcamera(tr2,cameradistance==0?-9.8f:cameradistance);   
}  
   nowTextNum=nowTextNum+3;
     }if (splitMessage[messageNum][nowTextNum+2].ToString()=="3")
     {

if (tr3)
{
    
gameObject.pclass().AutoRotateCamera.lerpatractcamera(tr3,cameradistance==0?-9.8f:cameradistance);   
}  
   nowTextNum=nowTextNum+3;
     }

 }
 }
public static KeyCode nextmessagekey;

    void Update() {
        //　メッセージが終わっているか、メッセージがない場合はこれ以降何もしない
        if (isEndMessage || allMessage == null) {
            return;
        }
 
        //　1回に表示するメッセージを表示していない	
        if (!isOneMessage) {
            //　テキスト表示時間を経過したらメッセージを追加
            if (elapsedTime >= textSpeed) {
                   extends();
                messageText.text += splitMessage[messageNum][nowTextNum];
 
                nowTextNum++;
                elapsedTime = 0f;
 
                //　メッセージを全部表示、または行数が最大数表示された
                if (nowTextNum >= splitMessage[messageNum].Length) {
                    isOneMessage = true; autotime=2;
           
                }
            }
            elapsedTime += Time.deltaTime;
 
            //　メッセージ表示中にマウスの左ボタンを押したら一括表示
            if (Input.GetMouseButtonDown(0)) {
                //　ここまでに表示しているテキストに残りのメッセージを足す
                messageText.text += splitMessage[messageNum].Substring(nowTextNum);
                isOneMessage = true;
            }
        //　1回に表示するメッセージを表示した
        } else {
 if (auto&&autotime>0)
 {
     autotime-=Time.deltaTime;
 }

            elapsedTime += Time.deltaTime;
 
            //　クリックアイコンを点滅する時間を超えた時、反転させる
            if (elapsedTime >= clickFlashTime) {
                clickIcon.enabled = !clickIcon.enabled;
                elapsedTime = 0f;
            }
 
            //　マウスクリックされたら次の文字表示処理
            if (Input.GetKeyDown(nextmessagekey)||Input.GetMouseButtonDown(0)||autotime<0) {
                nowTextNum = 0;
                messageNum++;
                messageText.text = "";
                clickIcon.enabled = false;
                elapsedTime = 0f;
                isOneMessage = false;
 
                //　メッセージが全部表示されていたらゲームオブジェクト自体の削除
                if (messageNum >= splitMessage.Length) {
                    isEndMessage = true;
                    messagecanvas.enabled=false;
          messagefinish();
                }
            }
        }
    }


    public void messagefinish(){
 if (icon!=null)
        {
            icon.enabled=false;

        }
        if (events!=null)
        {
            
events.Invoke();
events=null;
          
        }     if (action!=null)
        {
            
action();
action=null;
          
        }          
              }
    //　新しいメッセージを設定
  public void SetMessage(string message) {
      
        this.allMessage = message;
        //　分割文字列で一回に表示するメッセージを分割する
        splitMessage = Regex.Split(allMessage, @"\s*" + splitString + @"\s*", RegexOptions.IgnorePatternWhitespace);
        nowTextNum = 0;
        messageNum = 0;
        messageText.text = "";
        isOneMessage = false;
        isEndMessage = false;
        if (icon!=null)
        {
            icon.enabled=true;

        }
        
    }

    
    public void SetMessagePanel(string message, bool a=false,Sprite icons=null,System.Action ac=null) {

        if (message=="")
       {
events=null;
           return;
       }
       if (ac!=null)
       {
        action=ac;
       }
       auto=a;
       icon.sprite=icons;
    if (icons!=null)
    {
           icon.enabled=true;
    }else
    {
          icon.enabled=false;

    }
      
           
         SetMessage(message);
       messagecanvas.enabled=true;
     
           
    }


}
 