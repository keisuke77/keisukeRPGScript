using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public interface IDamagable
{
    void damage(int damage);
    void damage(int damage,bool crit);
}

[RequireComponent(typeof(FlickerModel))]
[RequireComponent(typeof(Animator))]
public class enemyhp : hpcore
{
  
    // Start is called before the first frame update
   
   [Range(0, 100)]
	 public int downoften=100;

    public string enemyname;
public motions DamageMotion;

public motions BigDamageMotion;




public Sprite icon;
    public GameObject deathparticle;
    public Effekseer.EffekseerEffectAsset deatheffect;
    Effekseer.EffekseerHandle handle;
    public float camerachangetime=0;
  public UnityEvent events;
 System.Action ac;
 public string deathmessage;
 public int exp;
public itemdrops itemdrops;



 public override void SetUp(){

 }

public override void OnDamage(int damage){
Itemkind item=itemcurrent.instance.Itemkind;
      	if (item!=null)
        {
          item.Resitance-=damage/10;
        }
        if (DamageMotion!=null)
        {
         
DamageMotion.Play(gameObject);
        }

anim.Play("allhit",0,0);
 
  if (keikei.kakuritu(downoften))
    {
BigDamageMotion.Play(gameObject);
anim.SetFloat("damagevalue",damage);
anim.SetInteger("damagevalue",damage);
anim.SetTrigger("damage");
	}
  
}

 public override void damagestop(){
   if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>()!=null)
   {
 gameObject.GetComponentIfNotNull<UnityEngine.AI.NavMeshAgent>().enabled=false;

   } }
 public override void recover(){
 if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>()!=null)
   {
 gameObject.GetComponentIfNotNull<UnityEngine.AI.NavMeshAgent>().enabled=true;
   }
 }



void OnDestroy()
{
    
Time.timeScale=1;
}


public override void OnDeath(){

if (anim!=null)
{
   anim.SetBool("death",true);anim.SetBool("dead",true);
anim.SetTrigger("death");
anim.SetTrigger("dead");
keikei.delaycall(()=>deathend(),3f);
}else{
   deathend();
}
   
        warning.message(enemyname+"を倒した！");
keikei.SetMessage(deathmessage,true,icon);
    
  
if (camerachangetime!=0)
{
keikei.atractcamera(camerachangetime,transform,13);
 handle= gameObject.PlayEffect(deatheffect,true);
}

}
    


//アニメーションコントローラから実行

public void deathend(){     
         
   if (deathparticle!=null)
   {
Instantiate(deathparticle,transform.position,transform.rotation);
   }
   if(itemdrops!=null)
   {
      
itemdrops.itemdropers(gameObject);

   }
ac=delegate()
{

if (killer!=null)
{
killer.acessdata().addexp(exp);
killer.acessdata().nowquest?.enemykill(enemyname);
}
handle.Stop(); 
events.Invoke();
};
keikei.dissolvedeath(gameObject,ac);


}







}
