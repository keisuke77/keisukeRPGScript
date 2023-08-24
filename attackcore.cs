using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AttackPart
{
    public Collider _Collider;
    public DamageInfo damageInfo;
    public string name;


    [HideInInspector]
    public attack attack;

    public AttackPart(GameObject obj, string names = "",float size=0.1f)
    {
    Create(obj,names,size);
    }

    public void Create(GameObject obj, string names = "",float size=0.1f)
    {
        BoxCollider col = obj.GetComponent<BoxCollider>();
        if (col == null)
        {
            col = obj.AddComponent(typeof(BoxCollider)) as BoxCollider;
           
        } 
        if (col!=null)
        {
               col.size=Vector3.one*size;
       _Collider = col;
        
        }
    
         name = names;
       
        SetUp();
    }

    public void SetUp()
    {if (_Collider)
    {
        SetUp(_Collider);
    }
    
    }

    public void SetUp(Collider _Collider)
    {
            attack = _Collider.gameObject.AddComponentIfnull<attack>();
            _Collider.isTrigger = true;
           _Collider.enabled = false;
        attack.damageInfo = damageInfo;

         }

    public void On()
    {SetUp();
    if (_Collider) _Collider.enabled = true;
  
       
    }

    public void Off()
    {SetUp();
       if (_Collider)  _Collider.enabled = false;
    }
}

public class attackcore : MonoBehaviour
{
    [Header("ここで設定すればAnimatorから名前指定でコライダ操作できる")]
    public List<AttackPart> AttackParts;

    public AttackPart CurrentAttackPart;
    public int basedamagevalue;
    public float baseforcepower;
    public string enemyname;
    public string AttackableTag = "Player";
    public bool overrideTag=true;

    [SerializeField, Range(0, 1)]
    private float CritRate = 0.1f;

    [SerializeField]
    private float CritMultiplier = 3f;
[Range(0,2)]
    public float AttackedObjAnimStopTime=0.1f;

    public void CurrentAttackPartSet(string name)
    {
        foreach (var item in AttackParts)
        {
            if (item.name == name)
            {
                CurrentAttackPart = item;
            }
        }
    }

public void AddAtackPart(AttackPart attackPart){
     if (AttackParts==null)
    { AttackParts.Add(attackPart);
        return;
    } 
    
    bool check =false;
foreach (var item in AttackParts)
{if ( item.name==attackPart.name)
{
    check=true;
}
   
}

if (!check)
{
     AttackParts.Add(attackPart);
}
}

public void AddAtackPartCurrent(){
   
    AddAtackPart(CurrentAttackPart);
}


    void Awake()
    {
        foreach (var item in AttackParts)
        {
            item.SetUp();
            item.attack.attackcore = this;
        }
    }
private void Start() {
    allofftriger();
}
    public void allofftriger()
    {
        foreach (var item in AttackParts)
        {
            item.Off();
        }
        CurrentAttackPart?.Off();
    }

public void SetBodyPartCurrent(bodypart bodypart){
 if (bodypart!=bodypart.no)
        {
             CurrentAttackPart=new AttackPart(bodypart.Getbodypart(gameObject.root()),"");
             AddAtackPartCurrent();
        }

}
    public void ontrigerName(string name)
    {
        foreach (var item in AttackParts)
        {
            if (item.name == name)
            {
                item.On();
            }
        }
    }

    public void offtrigerName(string name)
    {
        foreach (var item in AttackParts)
        {
            if (item.name == name)
            {
                item.Off();
            }
        }
    }

    public void ontriger()
    {
        CurrentAttackPart.On();
    }

    public void offtriger()
    {
        CurrentAttackPart.Off();
    }

    public bool attackon(
        GameObject attackedObj,
       DamageInfo damageInfos
    )
    {
     DamageInfo damageInfo=damageInfos.ShallowCopy();
        var crit = Random.value <= CritRate;

      damageInfo.damagValue = crit == true ? (int)(damageInfo.damagValue * CritMultiplier) :damageInfo.damagValue;
       damageInfo.damagValue += basedamagevalue;
       damageInfo.forceValue += baseforcepower;
       if (overrideTag)damageInfo.attackableTag=AttackableTag;
       
        var damadable = attackedObj.Damage(damageInfo,crit,gameObject);

        if (damadable && attackedObj.GetComponent<Animator>() != null)
        {
            Animator anim = attackedObj.GetComponent<Animator>();
            anim.speed = 0;
            keikei.delaycall(() => anim.speed = 1, AttackedObjAnimStopTime);
        }

        return damadable;
    }
}
