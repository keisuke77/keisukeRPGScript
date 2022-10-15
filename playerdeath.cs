using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class playerdeath : MonoBehaviour
{
    public Vector3 cameradistance;
    public Effekseer.EffekseerEffectAsset effect;

    bool once=false;
    public static System.Action ac;
    public datamanage datamanage;
    public movelift movelift;
    public Canvas deathcanvas;
    Animator anim;
    public CameraSetting deathcamera;
       // Start is called before the first frame update
   void Start() {if (deathcanvas!=null)
   {
    deathcanvas.enabled=false;
   }
     
anim=GetComponent<Animator>();
}
   
public void death(){
    
    if (once)return;
    if (datamanage!=null)
    {
        datamanage.HPreset();
    }
 gameObject.GetComponent<playerclass>().AutoRotateCamera.SetMessage("体力がなくなってしまった！！",true);
 DOTween.To(()=>gameObject.GetComponent<playerclass>().AutoRotateCamera.yaxis,(x)=>
 gameObject.GetComponent<playerclass>().AutoRotateCamera.yaxis=x,20,4f);
   warning.message("死んでしまった！");
   anim.SetBool("death",true);
       anim.SetTrigger("death");
       anim.SetBool("dead",true);



       gameObject.GetComponent<playerclass>().AutoRotateCamera.lerpatractcamera(transform,7);
       
 keikei.Effspawn(effect,transform);
    once=true;  keikei.delaycall(()=>gametransition(),3f);
   
    deathcanvas?.enabled(true);
   
}

bool gametransitiononce;
 public void gametransition(){
if (gametransitiononce)return;
gametransitiononce=true;if (gamemanager.instance!=null)
{
    
gamemanager.instance.gameend();
}
  
  keikei.gametransition(gameObject,"loss");

       
  }

}
