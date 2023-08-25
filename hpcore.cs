using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;
using DG.Tweening;
using System;
using System.Linq;
using UnityEngine.Events;

using Cysharp.Threading.Tasks;  // UniTaskのためのnamespaceを追加



[System.Serializable]
public struct DamageAnim
{[Range(0,100)]
    public int mindamage,maxdamage;

    public string name;

}
[System.Serializable]
public class basehp : MonoBehaviour
{
    public int maxHP = 100;
    public int HP = 100;
    public Text hptext;
    public Image hpImage;
    public Slider hpslider;
    public bool deathUIdestroy;
    public System.Action deathEvent;
    public bool DeathOnce;

    public bool DebugHPMugen;
    public void update()
    {
         HP = Mathf.Clamp(HP, 0, maxHP);
      if (hpImage != null)
        {
            hpImage.DOFillAmount((float)HP / maxHP, 0.5f);
        }
         if (hptext != null)
        {
            hptext.text = name + maxHP + "/" + HP;
        }

        if (hpslider != null)
        {
            hpslider.maxValue = maxHP;
            hpslider.value = HP;
        }

        if (HP <= 0&&!DeathOnce)
        {DeathOnce=true;
            death();
        } 
    }

   // HPが変更されたときのイベントを定義 
   public event Action<int> OnHpChanged;

    public void damage(int amount)
    {
        if (!DebugHPMugen)
        {
            HP = HP - amount;
            OnHpChanged?.Invoke(HP); // HPが変更されたのでイベントを呼び出す
        }
    }

    public void heal(int amount)
    {
        HP = HP + amount;
        OnHpChanged?.Invoke(HP); // HPが変更されたのでイベントを呼び出す
    }
    public void death()
    {
        if (deathUIdestroy)
        {
            if (hpslider)
                Destroy(hpslider.gameObject);
            if (hpImage)
                Destroy(hpImage.gameObject);
            
            if (hptext)
                Destroy(hptext.gameObject);
        }
        deathEvent();
    }
}
public class hpcore : basehp
{
    public ShakeParameters shakeParameters;
    public List<DamageAnim> damageAnims;
    public Animator anim;
    public GameObject damageTextPrefab;
    public Transform damageTextPos;
    FlickerModel FlickerModel;
    public bool DamagedRedMesh = true;
    public bool nodamage = false;
    public bool cooldown = false;
    public float cooldowntime = 0.8f;
    public GameObject killer;
    public EffectAndParticle HitEffect;
    public int defence;
    public int defaultdefencepower;
  
    public bool AttackerLook=true;
    [Range(0,20)]
    public float DamageShakePower=1;
    public GameObject healparticle;

    public bool deathonce;
    public UnityEvent deathEvent;
    public EffectAndParticle deatheffect;
    public CameraManager.Parameter deathCameraPram;
    public ChatData DeathChatData;
    public bool damageshake;



public Action cooldownHitAction;
public Action HpHealAction;

     public void muteki(float time, System.Action ac = null)
    {
        nodamage = true;
        keikei.delaycall(
            () =>
            {
                nodamage = false;
                ac();
            },
            time
        );
    }

    void Awake()
    {   
        base.deathEvent = () => Death();
        anim = GetComponent<Animator>();
        if (DamagedRedMesh)
        {
            FlickerModel = gameObject.AddComponentIfnull<FlickerModel>()as FlickerModel;
        }
        defence = defaultdefencepower;
        if (damageTextPrefab == null)
        {
            damageTextPrefab = (GameObject)Resources.Load("DamagePopup");
        }
       
        SetUp();
    }

    public virtual void SetUp() { }

    public virtual void hpheal(int amount)
    {
        base.heal(amount);
        HpHealAction();
        if (healparticle)
        {
           var obj = Instantiate(healparticle, transform.position, Quaternion.identity) as GameObject;
            obj.transform.parent = transform;
        }
    }

    public bool damage(int damage, bool crit, GameObject col)
    {
        return this.damage(damage, false, col.Collider());
    }

    public void OnDamageText(string st, bool crit = false)
    {

        Vector3 pos=   damageTextPos?damageTextPos.position:transform.position;

pos=pos+new Vector3(UnityEngine.Random.Range(-1,1),UnityEngine.Random.Range(-1,1),UnityEngine.Random.Range(-1,1));

        if (damageTextPrefab != null)
        {
            GameObject dmgText = Instantiate(
                damageTextPrefab,pos
             ,
                Quaternion.identity
            );
            dmgText.GetComponent<DamagePopup>().SetUp(st);

            if (crit)
            {
                dmgText.transform.localScale *= 1.5f;
                if (dmgText.GetComponent<TextMesh>()!=null)
                {
                       dmgText.GetComponent<TextMesh>().color = Color.red;
         
                }
                }
        }
    }

    public bool damage(
        int damage,
        bool crit = false,
        Collider attackedColl = null,
        bool sequence = false,
        GameObject killers = null
    )
    {
        if (sequence)
        {
            cooldown = false;
        }
        if (HP == 0 || anim.GetBool("dead") || nodamage || cooldown || damage == 0)
        {
            cooldownHitAction();
            return false;
        }
    
        cooldownstart();

       

     
        killer = killers;
        

        damage -= defence;
        damage = Mathf.Clamp(damage, 1, 9999);  
        
          if (damage > 0)
        {   if (anim != null)
        {
            anim.SetFloat("hp", HP);
            anim.SetTrigger("damage");
            anim.SetInteger("damagevalue", damage);
        }
         HitEffect?.Execute(killer?killer.transform:transform, attackedColl);

foreach (var item in damageAnims)
{
    if (item.mindamage<damage&&item.maxdamage>damage)
    {
        anim.CrossFadeAnimation(item.name,5);
    }
}



        
         if (hpImage != null)
        {
            
            hpImage.transform.DOPunchPosition(Vector3.one, 0.5f, 10, 0.1f);
        }
           
             }
        if (!nodamage)
        {
            base.damage(damage);
            if (hpImage != null)
            {
                keikei.uijump(hpImage.transform, damage * 6);
            }
        }
      
if (AttackerLook)
{
    if (killer!=null)
    {
          transform.LookAt(killer.transform,Vector3.up);
    }
  
}
if (damageshake)
{
 CameraShake.TriggerShake(shakeParameters);
      
}

   
       if ( FlickerModel!=null)
       {
        
        FlickerModel?.damagecolor();
       }

        OnDamageText(damage.ToString());

        OnDamage(damage);
        return true;
    }

    public virtual void OnDamage(int damage) { }

    public void cooldownstart()
    {
        cooldown = true;
        keikei.delaycall(()=>cooldown=false,cooldowntime);
     
    }

    public void Death()
    {  if (deathonce)return;
           
            deathonce = true;

        if (deathCameraPram!=null&&CameraManager.instance!=null)
        {
              CameraManager.instance.UpdatePram(deathCameraPram);

        }
       if (anim != null)
        {
            anim.SetBool("death", true);
            anim.SetBool("dead", true);
            anim.SetTrigger("death");
            anim.SetTrigger("dead");
        }
        if(deathEvent!=null){
            deathEvent.Invoke();
        }
        if (TryGetComponent(out attackcore attackcore))
        {
            attackcore.allofftriger();
        }  
        //武器のコライダを切る
if (deatheffect!=null)
{
      deatheffect.Execute(transform, null);
    
}
        if (ChatExecute.instance!=null&&DeathChatData!=null)
      { 
ChatExecute.instance.Execute(DeathChatData,OnDeath);
      }else
      {
        OnDeath();
      }
    }

    public virtual void OnDeath() { }

    public virtual void damagestop() { }

    public virtual void recover() { }

    // Update is called once per frame
    void Update()
    {base.update();
        
   
    }
}
