using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;
using DG.Tweening;
 
using UnityEngine.Events;
using ItemSystem;
[System.Serializable]
public class keyduration
{
    public KeyCode key;
    public float duration=0.1f;
    public bool able;
    public UnityEvent putkey;
public void execute(){
    if (key!=null)
    {
           if (!able&&key.keydown())
    {
        able=true;
        putkey.Invoke();
        keikei.delaycall(()=>able=false,duration);
    }
    }
}
}


[System.Serializable]
public class basehp:MonoBehaviour
{
    public int maxHP = 100;
    public int HP = 100;
    public Text hptext;
    public Image hpImage; 
    public Slider hpslider; 
    public bool deathUIdestroy;
    public System.Action deathEvent; 
    void SetUp(){
        if (HP==0)
        {
        HP=maxHP;   
        } 
        if (HP>maxHP)
    {
        maxHP=HP;
    } 
      if (hpImage!=null)
{
    hpImage.DOFillAmount((float)HP/maxHP, 0.5f).SetEase(Ease.InQuart); 
}
    }


public void update(){
       HP = Mathf.Clamp(HP ,0,maxHP);
 if (hptext!=null)
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

public void damage(int amount){
    HP=HP-amount;
    hpImage.DOFillAmount((float)HP/maxHP, 0.5f).SetEase(Ease.InQuart);
}

  public void heal(int amount){

HP=HP+amount;
  }
  public void death(){
if (deathUIdestroy)
{
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

}
deathEvent();
  }
}





public class hpcore : basehp{ 
    public Animator anim;
    public GameObject damageTextPrefab;
   public basehp basehp;
    FlickerModel FlickerModel;
    public bool DamagedRedMesh=true;
    public bool nodamage=false;
    public GameObject HitParticle;
    public bool cooldown=false;
    public float cooldowntime=0.8f;
    public GameObject healparticle;
    public GameObject killer;
    public Effekseer.EffekseerEffectAsset hiteffect;
    public int defence;
    public int defaultdefencepower;
    public bool deathonce;
    public bool damageshakepos;
    public GameObject deathparticle;
    public Effekseer.EffekseerEffectAsset deatheffect;
    public keyduration kaihi;
    public UnityEvent kaihieve;
    // Start is called before the first frame update


public void muteki(float time,System.Action ac=null){
nodamage=true;
keikei.delaycall(()=>{nodamage=false;ac();},time);
}

    public void Start()
    {
anim=gameObject.cclass().anim;

    }
void Awake()
{basehp.deathEvent=()=>death();
gameObject.cclass().hpcore=this;
if (DamagedRedMesh)
{
FlickerModel=gameObject.AddComponentIfnull<FlickerModel>();
}
  defence=defaultdefencepower;
   if (damageTextPrefab==null)
       {
           damageTextPrefab=(GameObject)Resources.Load("DamagePopup");
       } 
    SetUp();
}
public virtual void SetUp(){


    }



public virtual void hpheal(int amount){
    basehp.heal(amount);
warning.instance?.message("HPが"+amount.ToString()+"回復した！");
GameObject obj;if (healparticle!=null)
{
obj=Instantiate(healparticle, transform.position, Quaternion.identity)as GameObject;
obj.transform.parent=transform;
    
}
}


public bool damage(int damage,bool crit,GameObject col)
{

return this.damage(damage,false,col.Collider());

}




public bool damage(int damage,bool crit=false,Collider coll=null,bool sequence=false,GameObject killers=null)
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

    if (kaihi.able)
    {
       
if (damageTextPrefab!=null)
{GameObject dmgText = Instantiate(damageTextPrefab, gameObject.pclass().anim.gameObject.transform.position, Quaternion.identity);
            dmgText.GetComponent<DamagePopup>().SetUp("避");
}
anim.SetTrigger("kaihi");
anim.speed=0;
keikei.delaycall(()=>anim.speed=1,0.1f);
kaihieve.Invoke();
return false; 
    }

    

if (killers!=null)
    { killer=killers;
    }
  
   damage-=defence;
damage = Mathf.Clamp(damage,1,9999);
if (!nodamage)
{
    basehp.damage(damage);
        if (basehp.hpImage!= null)
        {
            keikei.uijump(basehp.hpImage.transform, damage * 6);
        }
}
    
if (damage>0)
{
anim.speed=0;
keikei.delaycall(()=>anim.speed=1,0.1f);
if (HitParticle!=null)
{if (coll!=null&&killer!=null)
{
     HitParticle.Instantiate(coll.ClosestPointOnBounds(killer.transform.position));
}else
{
    HitParticle.Instantiate(transform.position);
}
    
}

if (hiteffect!=null)
{
if (coll!=null&&killer!=null)
{
     
hiteffect.Play(coll.ClosestPointOnBounds(killer.transform.position));
}else
{
   
hiteffect.Play(transform.position);
}

}
       
    keikei.backforce(transform.root.gameObject,20);

}

    
 
 if (damageshakepos)
 {
transform.DOPunchPosition(Vector3.one, 0.5f, 10, 0.4f);
 }
if (basehp.hpImage!=null)
{basehp.hpImage.transform.DOPunchPosition(Vector3.one, 0.5f, 10, 0.1f);
}
if (anim!=null)
{
anim.SetFloat("hp",basehp.HP);
anim.SetTrigger("damage");
anim.SetFloat("damagevalue",damage);

}

FlickerModel?.damagecolor();

if (damageTextPrefab!=null)
{GameObject dmgText = Instantiate(damageTextPrefab, gameObject.pclass().anim.gameObject.transform.position, Quaternion.identity);
            dmgText.GetComponent<DamagePopup>().SetUp(damage);
      
    if (crit)
      {
          dmgText.transform.localScale*=1.5f;
          dmgText.GetComponent<TextMesh>().color=Color.red;
      }
}
    OnDamage(damage);
    return true;
}
 
public virtual void OnDamage(int damage){
}


public void cooldownstart(){ 
cooldown=true;
Invoke("cooldownend",cooldowntime);
}


public void cooldownend(){
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
        basehp.update();
if (kaihi!=null)
{
    kaihi.execute();
}
    }
}
