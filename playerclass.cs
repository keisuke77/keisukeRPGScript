using UnityEngine;
using System;

using ItemSystem;
public class playerclass : CharactorClass
{//プレイヤーが持つ可能性のあるクラスをまとめたもの

//プレイヤーの発動できる1クラス内でまとめられない複合処理系コマンドをまとめたクラス　キャラチェンジなど

public AutoRotateCamera AutoRotateCamera;
public keiinput keiinput;
public itemcurrent itemcurrent;
public itemmanage itemmanage;
public datamanage datamanage;
public meleecamera meleecamera;
public interactionlist interactionlist;
public itemuseplace itemuseplace;
public message message;
public mp mp;
public playerMovePram playerMovePram;
public Collider RangeDamageCollider; 
public UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
public GameObject Canvasgroup;
public PlayerControll PlayerControll;
	
	


	public void UpdateControlObj(GameObject obj,xyz xyzs){
        playerMovePram.nowxyz=xyzs;
        playerMovePram.trans=gameObject.transform;
        playerMovePram.rb=obj.AddComponentIfnull<Rigidbody>();
		playerMovePram.rb.constraints = RigidbodyConstraints.FreezeRotation;
		playerMovePram.controller=obj.AddComponentIfnull<CharacterController>();
        UnityChanControlScriptWithRgidBody.controller=obj.AddComponentIfnull<CharacterController>();
UnityChanControlScriptWithRgidBody.anim=obj.AddComponentIfnull<Animator>();
playerMovePram.anim=obj.AddComponentIfnull<Animator>();
if (AutoRotateCamera!=null)
{
	
AutoRotateCamera.lerpatractcamera(obj.transform);
AutoRotateCamera.Player=obj.transform;
AutoRotateCamera.nowxyz=xyzs;

}
		}

public void PlayerMoveAction(System.Action ac){

anim.enabled=false;
PlayerControll.enabled=false;
ac();
PlayerControll.enabled=true;
anim.enabled=true;
}


public void SetMessageAtractCamera(Transform trans,string messagetext,System.Action action=null,bool autoprocess=false,float cameradistance=0){
if (cameradistance==0)
{	
AutoRotateCamera?.lerpatractcamera(trans);
}else
{
	
AutoRotateCamera?.lerpatractcamera(trans,cameradistance);
}
message.SetMessagePanel(messagetext,autoprocess,null,()=>{
    AutoRotateCamera?.atractend();
    action();

});

}

		public void ResetControlObj(){

			UpdateControlObj(gameObject,playerMovePram.defaultxyz);

		}

		public void scalechange(float num){
gameObject.scalechange(num);
if (Canvasgroup!=null)
{
Canvasgroup.scalechange(1/num);
}
if (AutoRotateCamera!=null)
{
AutoRotateCamera.distance=
AutoRotateCamera.distance*num;
} 
gameObject.pclass().playerMovePram.movespeed=num;
}



 public void gametransition(string scenename){
    
Action ac=delegate(){
   keikei.fadescene(scenename);
   if (charactorchange!=null)
	{
  charactorchange.characterhide();
  }
      };
	  if (U10PS_DissolveOverTime!=null)
	  {
		 U10PS_DissolveOverTime.dissolve.dissolveOut(ac);
	  }else
	  {
ac();
	  }

         }



 public void charactorchangeitem(){

      CharacterChange();
	  if (itemuse.instance!=null)
	  {
		 itemuse.instance.itemused();
	  }
         }

    



}