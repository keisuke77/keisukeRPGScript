using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameObjectの拡張クラス
/// </summary>
[System.Serializable]
public class DamageInfo
{
    [Range(0,1000)]
   public int damagValue; 
   public float forceValue;
   public bool sequenceHit;
   public string attackableTag;
    public object Clone()                            // シャローコピーになります。
  {
    return MemberwiseClone();
  }
    public DamageInfo ShallowCopy()                          //シャローコピー
  {
    return (DamageInfo)this.Clone();
  }
}
public static class HPSystemExtension
{
    //万能ダメージクラス

      public static bool Damage(this GameObject attacked,
       DamageInfo damageInfo,
        bool crit = false,GameObject attacker=null
    )
    {

       return attacked.Damage(damageInfo.damagValue,damageInfo.attackableTag,crit,damageInfo.sequenceHit,attacker,damageInfo.forceValue);
    }

    public static bool Damage(
        this GameObject attacked,
        int damagevalue,
        string objtag,
        bool crit = false,
        bool sequencehit = false,
        GameObject attacker = null,
        float forcepower = 0
    )
    {
        var rootObj = attacked.root();
        bool damadable=false;
        if (rootObj.CompareTag(objtag))
        {
            if (rootObj.GetComponent<hpcore>() != null)
            {
                damadable = rootObj
                    .GetComponent<hpcore>()
                    .damage(damagevalue, crit, attacked.Collider(), sequencehit, attacker);
            }
            if (damadable && forcepower > 0)
            {
                if (attacked.GetComponent<ForceableObj>() != null)
                {
                    attacked.GetComponent<ForceableObj>().AddForce(attacker, forcepower);
                
                }
                if (attacked.GetComponent<DOForce>() != null)
                {
                    attacked.GetComponent<DOForce>().AddForce(attacker, forcepower);
                }
            }
            return damadable;
        }
        return false;
    }

    public static void PlayerAddForce(this GameObject attacked, Vector3 force)
    {
        attacked.root().GetComponent<ForceableObj>().AddForce(force);
    }

    public static void collset(this GameObject obj, int damagevalue, string AttackableTag = "Enemy")
    {
        if (obj.GetComponent<Collider>() == null)
        {
            var col = obj.AddComponent(typeof(BoxCollider)) as Collider;
            col.isTrigger = true;
            col.enabled = false;
        }

        var attack = obj.AddComponentIfnull<attack>() as attack;
        attack.damageInfo.damagValue = damagevalue;
        attack.damageInfo.attackableTag = AttackableTag;
    }

    public static void damageset(this GameObject obj, int damagevalue)
    {
        obj.GetComponentIfNotNull<attackcore>().basedamagevalue = damagevalue;
    }



    public static GameObject Getbodypart(this bodypart bodypart, GameObject obj)
    {
        switch (bodypart)
        {
            case bodypart.righthand:

                return obj.GetComponent<GetBodyPart>()
                    .GetRightHand();
                break;
            case bodypart.lefthand:

                return obj.GetComponent<GetBodyPart>()
                    .GetLeftHand();
                break;
            case bodypart.rightfoot:

                return obj.GetComponent<GetBodyPart>()
                    .GetRightFoot();
                break;
            case bodypart.leftfoot:
                return obj.GetComponent<GetBodyPart>()
                    .GetLeftFoot();
                break;
            case bodypart.weapons:
                return obj.GetComponent<GetBodyPart>()
                    .GetWeapon();      break;
            case bodypart.no:
                return null;
                break;
            default:
                return null;
                break;
        }
    }
}
