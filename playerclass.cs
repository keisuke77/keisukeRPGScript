using UnityEngine;
<<<<<<< HEAD
using System;

using ItemSystem;
public class playerclass : CharactorClass
{//プレイヤーが持つ可能性のあるクラスをまとめたもの

//プレイヤーの発動できる1クラス内でまとめられない複合処理系コマンドをまとめたクラス　キャラチェンジなど

public AutoRotateCamera AutoRotateCamera;
public itemcurrent itemcurrent;
public itemmanage itemmanage;
public datamanage datamanage;
public interactionlist interactionlist;
public itemuseplace itemuseplace;
public message message;
public playerMovePram playerMovePram;
public Collider RangeDamageCollider; 
public UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
public GameObject Canvasgroup;
public PlayerControll PlayerControll;
	public weaponchange weaponchange;
	


	public void UpdateControlObj(GameObject obj,xyz xyzs){
		if (playerMovePram!=null)
		{
			  playerMovePram.nowxyz=xyzs;
        playerMovePram.trans=transform;
        playerMovePram.rb=obj.AddComponentIfnull<Rigidbody>();
		playerMovePram.rb.constraints = RigidbodyConstraints.FreezeRotation;
		playerMovePram.controller=obj.AddComponentIfnull<CharacterController>();
       playerMovePram.anim=obj.AddComponentIfnull<Animator>();
		}
		if (UnityChanControlScriptWithRgidBody!=null)
		{
UnityChanControlScriptWithRgidBody.controller=obj.AddComponentIfnull<CharacterController>();
UnityChanControlScriptWithRgidBody.anim=obj.AddComponentIfnull<Animator>();
		}
		
		if (AutoRotateCamera!=null)
{
AutoRotateCamera.lerpatractcamera(obj.transform);
AutoRotateCamera.Player=obj.transform;
AutoRotateCamera.nowxyz=xyzs;
}
}

public void PlayerMoveAction(System.Action ac){
if (anim!=null)
{
	
anim.enabled=false;
}
if (PlayerControll!=null)
{
	
PlayerControll.enabled=false;
}
ac();
if (PlayerControll!=null)
{
	
PlayerControll.enabled=true;
}if (anim!=null)
{
	
anim.enabled=true;
}
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

    

=======

public class playerclass : MonoBehaviour
{
    public AutoRotateCamera AutoRotateCamera;
public keiinput keiinput;
public itemcurrent itemcurrent;
public itemmanage itemmanage;
public datamanage datamanage;
public Effekseer.EffekseerEmitter playeremitter;
public interactionlist interactionlist;
public itemuseplace itemuseplace;
    
	void Awake () 
	{playeremitter=GetComponent<Effekseer.EffekseerEmitter>();
	datamanage=GetComponent<datamanage>();
		int maxDisplayCount = 2;
		for (int i=0; i<maxDisplayCount && i<Display.displays.Length; i++) {
			Display.displays[i].Activate();
		}
	}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae


}