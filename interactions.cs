
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
public RandomItemkind RandomItemkind;
public bool once;
public bool endvanish;
public int count;
public Itemkind needitem;
public Itemkind Itemkind;
public interactionsuceess suceeesaction;

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
    



obj.root().boolset(animstringbool);
      
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




