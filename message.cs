using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using DG.Tweening;
using UnityEngine.Events;


public class message : MonoBehaviour {

    //　表示するメッセージ
    [SerializeField]
    [TextArea(1, 20)]
    private string allMessage = "今回はRPGでよく使われるメッセージ表示機能を作りたいと思います。\n"
            + "メッセージが表示されるスピードの調節も可能であり、改行にも対応します。\n"
            + "改善の余地がかなりありますが、               最低限の機能は備えていると思われます。\n"
            + "ぜひ活用してみてください。\n<>"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ"
            + "あああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ";
    //　使用する分割文字列
    [SerializeField]
    private string splitString = "<>";
    public System.Action action;
    public bool Autostart;
    //　テキストスピード
    [SerializeField]
    private float textSpeed = 0.1f;
   public Image icon;
    public Canvas messagecanvas;
    public bool auto;
    
     //　マウスクリックを促すアイコン
   public eventKeyImage eventKeyImage;

    public Text tmpro;
   public string[] mes;
   public int mesNum = 0;
   
   
   
    void Awake() {if (gameObject.pclass()!=null)
    {
        gameObject.pclass().message=this;
    
    }
    
           finish();
       }



       void Start()
       {    if (Autostart)
           {
               SetMessagePanel(allMessage);
           } 
       
       }

void OnMouseDown()
{
    OnDown();
}

    public void SetMessage(string message){
SetMessagePanel(message);
    }
    public void SetMessagePanel(string message, bool autos=false,Sprite icons=null,System.Action ac=null) {

        if (message=="")
       {
           return;
       }
       if (ac!=null)
       {
        action=ac;
       }
       auto=autos;
       
    if (icons!=null)
    {icon.sprite=icons;
    }
   
        messagecanvas.enabled=true;
        //　分割文字列で一回に表示するメッセージを分割する
        mes = Regex.Split(message, @"\s*" + splitString + @"\s*", RegexOptions.IgnorePatternWhitespace);
        OnDown();

        }

    //画面とかタップされたらよばれる関数
    public void OnDown()
    {
        //tmproがTweenしているかどうか
        if(DOTween.IsTweening(tmpro))
        {
            //Tween中なら即終了
            tmpro.text = mes[mesNum - 1];
            tmpro.DOKill();
        }
        else
        {
            
            if(mesNum > mes.Length - 1){
                finish();
                return;
            }
            //一度textを無にしてから書き込もうね
            tmpro.text = "";
            tmpro.DOText(mes[mesNum], mes[mesNum].Length *textSpeed).OnComplete(()=>{
                if (auto)
                {
                    OnDown();
                }else
                {   
                    if (eventKeyImage!=null)
                    {
                        eventKeyImage.eve=()=>OnDown();
                        StartCoroutine(eventKeyImage.SetUpImageEvent());
                        
                    }
        
                }
            });
            mesNum++;
        }
    }


public void finish(){
     mesNum=0;
         if (action!=null)
        {
            action();
            action=null;    
        }   
        messagecanvas.enabled=false; 
}




}
 