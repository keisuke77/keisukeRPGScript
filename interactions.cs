<<<<<<< HEAD
//  interactions.cs
//  http://kan-kikuchi.hatenablog.com/entry/GetComponentInParentAndChildren
//
//  Cr
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
<<<<<<< HEAD
using ItemSystem;
using System;
=======


>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

[System.Serializable]
public class interactionsuceess:interaction{


}

[System.Serializable]
<<<<<<< HEAD
public class interaction 
{
  
public animstringbool animstringbool;
=======
public class interaction
{public animstringbool animstringbool;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public string messagetext;
public bool colidecall;
SpriteRenderer spriteRenderer;
public bool autoprocess;
public bool save;
public string interactiontext;
public UnityEvent kaiwaendevents;
public UnityEvent interactionevent;
<<<<<<< HEAD

=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public string scenename;
System.Action action;
public warpdata warpdata;
public Transform animpos;
public shopset shopset;
public bool atractcamera;
<<<<<<< HEAD
public bool multcamera;
public RandomItemkind RandomItemkind;
public CameraSetting CameraSetting;
=======
public RandomItemkind RandomItemkind;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public bool once;
public bool endvanish;
public int count;
public Itemkind needitem;
public Itemkind Itemkind;
<<<<<<< HEAD
public bool playerstop;
public interactionsuceess suceeesaction;
public bool lookat;
=======
public interactionsuceess suceeesaction;

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
<<<<<<< HEAD
      if (playerclass.itemcurrent!=null)
      {
        
if (!(playerclass.itemcurrent.Itemkind==needitem||needitem==keikei.noitem)){

warning.instance?.message(needitem.GetItemName()+"が必要だ");
return;
}

      }
=======
if (!(playerclass.itemcurrent.Itemkind==needitem||needitem==keikei.noitem)){

warning.message(needitem.GetItemName()+"が必要だ");
return;
}

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

 if (save)
    {
      playerclass.datamanage.save();
    }
    


<<<<<<< HEAD
if (animstringbool!=null)
{
obj.root().boolset(animstringbool);   
}
=======

obj.root().boolset(animstringbool);
      
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
<<<<<<< HEAD
        obj.pclass().gametransition(scenename);
=======
        keikei.gametransition(obj.root(),scenename);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
      }
      if (warpdata!=null)
      {
        warpdata.warps(obj);
      }
<<<<<<< HEAD
    if (lookat)
    {
    interactionenter.gameObject.transform.LookAt( playerclass.gameObject.transform);
    }
      if (RandomItemkind!=null)
      {
        playerclass.itemmanage.additem(RandomItemkind.GetRandomOne(),true);
=======
    
      if (RandomItemkind!=null)
      {
        playerclass.itemmanage.Randomgive(RandomItemkind,true);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

      }
      if (shopset!=null)
      {shopset.open(obj);
      }
      if (Itemkind!=null)
      {
<<<<<<< HEAD
        playerclass.itemmanage?.give(Itemkind,true);
=======
        playerclass.itemmanage.give(Itemkind,true);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
endvanish=true;
      }
     
if (interactionevent!=null)
{
    
interactionevent.Invoke();
}

if (messagetext!="")
{if (atractcamera)
{
<<<<<<< HEAD
   playerclass.SetMessageAtractCamera(interactionenter.gameObject.transform,messagetext,()=>{kaiwaendevents.Invoke();
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
   playerclass.message.SetMessagePanel(messagetext,true);
=======
   playerclass.AutoRotateCamera.SetMessageAtractCamera(interactionenter.gameObject.transform,messagetext,()=>{kaiwaendevents.Invoke();
      playerclass.AutoRotateCamera.atractend();}
      ,autoprocess);
   
}else
{
   playerclass.AutoRotateCamera.SetMessage(messagetext,true);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
  
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
<<<<<<< HEAD
}

    public override bool Equals(object obj)
    {
        return obj is interaction interaction &&
               messagetext == interaction.messagetext;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(messagetext);
    }
=======
}    

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}




