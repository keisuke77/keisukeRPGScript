
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;



[System.Serializable]
public class interactionsuceess:interaction{


}

[System.Serializable]
public class interaction
{public animstringbool animstringbool;
public string messagetext;
public bool colidecall;
SpriteRenderer spriteRenderer;
public bool autoprocess;
public bool save;
public string interactiontext;
public UnityEvent kaiwaendevents;
public UnityEvent interactionevent;
public string scenename;
System.Action action;
public warpdata warpdata;
public Transform animpos;
public shopset shopset;
public bool atractcamera;
public bool multcamera;
public RandomItemkind RandomItemkind;
public CameraSetting CameraSetting;
public bool once;
public bool endvanish;
public int count;
public Itemkind needitem;
public Itemkind Itemkind;
public bool playerstop;
public interactionsuceess suceeesaction;
public bool lookat;
playerclass playerclass;





public void createinteraction(interactionenter interactionenter,GameObject obj){
    
   playerclass =obj.pclass();
    if (Itemkind!=null)
    {
      interactiontext=Itemkind.GetItemName();
    }
   
     if (interactiontext=="")
    {
        return;
    }

    if (!once)
    {
      
  once=true;
    }else
    {
      return;
    }
  
  if (!needitem)
{
  needitem=keikei.noitem;
}




    action=delegate(){
if (!(playerclass.itemcurrent.Itemkind==needitem||needitem==keikei.noitem)){

warning.message(needitem.GetItemName()+"が必要だ");
return;
}


 if (save)
    {
      playerclass.datamanage.save();
    }
    


if (animstringbool!=null)
{
obj.root().boolset(animstringbool);   
}
      if (suceeesaction.interactiontext!="")
      {
   interactionenter.nowinteraction=(interaction)suceeesaction;
    
   interactionenter.nowinteraction.createinteraction(interactionenter,obj);
      }
      if (animpos)
      {
        keikei.dokan=animpos;
      }
      if (scenename!="")
      {
        keikei.gametransition(obj.root(),scenename);
      }
      if (warpdata!=null)
      {
        warpdata.warps(obj);
      }
    if (lookat)
    {
    interactionenter.gameObject.transform.LookAt( playerclass.gameObject.transform);
    }
      if (RandomItemkind!=null)
      {
        playerclass.itemmanage.Randomgive(RandomItemkind,true);

      }
      if (shopset!=null)
      {shopset.open(obj);
      }
      if (Itemkind!=null)
      {
        playerclass.itemmanage.give(Itemkind,true);
endvanish=true;
      }
     
if (interactionevent!=null)
{
    
interactionevent.Invoke();
}

if (messagetext!="")
{if (atractcamera)
{
   playerclass.AutoRotateCamera.SetMessageAtractCamera(interactionenter.gameObject.transform,messagetext,()=>{kaiwaendevents.Invoke();
      playerclass.AutoRotateCamera.atractend();}
      ,autoprocess);
      playerclass.AutoRotateCamera.CameraSettingSet(CameraSetting);
   
}else if(multcamera)
{keikei.multcamera.m_gameObjects[0]=playerclass.gameObject;
keikei.multcamera.m_gameObjects[1]=interactionenter.gameObject;
keikei.multcamera.GetComponent<Camera>().enabled=true;
  playerclass.message.SetMessagePanel(messagetext,false,null,()=>keikei.multcamera.GetComponent<Camera>().enabled=false); 
}else
{
   playerclass.AutoRotateCamera.SetMessage(messagetext,true);
  
}
        
      
}

deleteinteraction();
 if (endvanish)
          {
          keikei.vanisheffect.Instantiate(interactionenter.gameObject.transform); 
          keikei.destroy(interactionenter.gameObject);
          }


    };

if (colidecall)
{
  action();
}else
{
  
if (Itemkind==null)
{
  count= playerclass.interactionlist.createinteraction(interactiontext,action);
}else{
  count= playerclass.interactionlist.createinteraction(Itemkind.GetItemName(),action);
  
}
}
  


}




    public void deleteinteraction()
{

  playerclass.interactionlist.deleteinteraction(count);
        once=false;
}    

}




