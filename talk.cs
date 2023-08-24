using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

[System.Serializable]
public class ChatCamera {
      public ChatData ChatData;
  public CameraManager.Parameter Parameter;
 public Camera CutCamera;
 public UnityEvent unityEvent;

 public void Execute(System.Action ac=null){
  
   if (CutCamera)
   {
    CutCamera.enabled=true;
   }
         ChatExecute.instance.Execute(
            ChatData,
            () =>
            {  
                   if (ac!=null)
             {
                ac();
                if (unityEvent!=null)
                {
                     unityEvent.Invoke();
                }
               
             }
            });  if ( CameraManager.instance!=null)
    {
         CameraManager.instance?.UpdatePram(Parameter);
    }
 }
}
[System.Serializable]
public class ChatCameras {
    public List<ChatCamera> chatCameras;
    public int interval;

   public System.Action EndCall=null;
 public void Execute(int num=0){
if (num>=chatCameras.Count)
{if (EndCall!=null) EndCall();
   return;
}
foreach (var item in chatCameras)
{if (item.CutCamera)
{
       item.CutCamera.enabled=false;

}
 }
 chatCameras[num].Execute(()=>keikei.delaycall(()=>this.Execute(num+1),Time.deltaTime*interval));  
 }
}

public class talk : MonoBehaviour
{
    public Button button;
     public UnityEvent kaiwaendevents;
     public IconGenerate IconGenerate;
    GameObject Talker;
public ChatCameras ChatCameras;

    [Button( "TalkEvent", "実行")]
public int a;

       
    // Start is called before the first frame update
    void Start()
    {
      IconGenerate.SetUp(gameObject);
        Exit();
    }


	GameObject temp;

     public void TalkEvent(GameObject obj){
Talker=obj;
TalkEvent();
     }
     
    public void TalkEvent()
    {    
        Talker.transform.DOLookAt(transform.position, 1, AxisConstraint.Y);
         transform.DOLookAt(Talker.transform.position, 1, AxisConstraint.Y);
        
        Talker.Stop();
          Talker.root().GetComponent<AnimBoolSet>().Stop = true; 
        
         temp=Talker;
     ChatCameras.EndCall=()=>{
        if (kaiwaendevents!=null)
        {  kaiwaendevents.Invoke();
            
        }
      
  CameraManager.instance.DefaultPram();
       
                temp.Restart();
                Talker.root().GetComponent<AnimBoolSet>().Stop = false; 
                
        };

        ChatCameras.Execute(0);
        Exit();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.proottag())
        {   
            Talker = collisionInfo.gameObject; 
   
              if (button != null)
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(() =>
                {
                    TalkEvent();
                    return;
                });
            }
            IconGenerate.On();
        }
    }

    public void Exit()
    {IconGenerate.Off();
        Talker = null;
           if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.proottag())
        {
            Exit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Talker != null)
        {
            if (keiinput.Instance.interaction)
            {
                TalkEvent();
            }
          transform.DOLookAt(Talker.transform.position, 1, AxisConstraint.Y);
          }
    }
}
