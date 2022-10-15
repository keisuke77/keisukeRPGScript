using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

 
public class hpcore : MonoBehaviour{ 
      [Range(2, 0)]
     public float timeScale=1;
    public Animator anim;
    public GameObject damageTextPrefab;
    public int maxHP = 100;
    public int HP = 100;
    public FlickerModel FlickerModel;
    public Text hptext;
    public Image hpImage; 
    public bool nodamage=false;
    public GameObject HitParticle;
    public bool cooldown=false;
    public int cooldowntime=2;
    public GameObject healparticle;
    public GameObject killer;
    public Slider hpslider; 
    public Effekseer.EffekseerEffectAsset hiteffect;
    public int defence;
public bool deathonce;
    // Start is called before the first frame update

    public void Start()
    {

FlickerModel=GetComponent<FlickerModel>();
anim=GetComponent<Animator>();
       
       if (HP>maxHP)
       {
           maxHP=HP;
       }
       if (damageTextPrefab==null)
       {
           damageTextPrefab=(GameObject)Resources.Load("DamagePopup");
       } 
       

        SetUp();
    }
    public virtual void SetUp(){
    
    }



public virtual void hpheal(int amount){
HP=HP+amount;
warning.message("HPが"+amount.ToString()+"回復した！");
GameObject obj;
obj=Instantiate(healparticle, transform.position, Quaternion.identity)as GameObject;
obj.transform.parent=transform;
}




public bool PlayerOREnemydamage(int damagevalue,bool crit,GameObject col,bool player)
{
if (player)
{
    if (gameObject.proottag())
    {
       return this.damage(damagevalue,crit,col);
    }
}else
{
     if (gameObject.eroottag())
    {
       return this.damage(damagevalue,crit,col);
    }
}
  return false;
}





public bool damage(int damage,bool crit,GameObject col)
{

return this.damage(damage,false,col.Collider());

}




public bool damage(int damage,bool crit=false,Collider coll=null,bool sequence=false)
{ 
    if (sequence)
    {
        cooldown=false;
    }
    
     if (HP==0||anim.GetBool("dead")||nodamage||cooldown||damage==0)
    {
        return false;
    }

    
    cooldownstart();
    if (coll!=null)
    { killer=coll.gameObject;
    }
  
   damage-=defence;
damage = Mathf.Clamp(damage,1,9999);
 HP = HP-damage; 

anim.SetFloat("hp",HP);
if (HP>0)
{
anim.SetTrigger("damage");
anim.SetFloat("damagevalue",damage);
}

FlickerModel.damagecolor();
HitParticle?.Instantiate(coll?.ClosestPointOnBounds(transform.position)??transform.position);
hiteffect?.Play(coll?.ClosestPointOnBounds(transform.position)??transform.position);
     
if (damageTextPrefab!=null)
{GameObject dmgText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            dmgText.GetComponent<DamagePopup>().SetUp(damage);
      
    if (crit)
      {
          dmgText.transform.localScale*=1.5f;
          dmgText.GetComponent<Text>().material.color=Color.red;
          keikei.Effspawns(0,gameObject.transform);
      }
}
    OnDamage(damage);
    return true;
}
 
public virtual void OnDamage(int damage){
}


public void cooldownstart(){
damagestop();
cooldown=true;
Time.timeScale=timeScale;
Invoke("cooldownend",cooldowntime);
}


public void cooldownend(){
Time.timeScale=1;
recover();
    cooldown=false;
}

public void death(){
if (GetComponent<triggeronoff>()!=null)
{ GetComponent<triggeronoff>().trigerswich(false);
}
if (GetComponent<trrigeronofflist>()!=null)
{ GetComponent<trrigeronofflist>().offtriger();
}
//武器のコライダを切る
     
if (!deathonce)
{ deathonce=true;

if (hpslider!=null)
       {
             Destroy(hpslider.gameObject);
       }
   if (hpImage!=null)
   {
     Destroy(hpImage.gameObject);
   } 
   if (hptext!=null)
   {
     Destroy(hptext.gameObject);
   }

  OnDeath();
}
}

public virtual void OnDeath(){


}
public virtual void damagestop(){


}
public virtual void recover(){


}
    // Update is called once per frame
    void Update()
    {

   HP = Mathf.Clamp(HP ,0,maxHP);
   if (hpImage!=null)
   {
       hpImage.fillAmount = (float)HP/maxHP;
   }if (hptext!=null)
   {
       hptext.text = name+maxHP+"/"+HP;
   }

      if (hpslider!=null)
   {
        hpslider.maxValue=maxHP;   
         hpslider.value=HP;
   }



    
if (HP<=0)
{  
    death();
}
    }
}
