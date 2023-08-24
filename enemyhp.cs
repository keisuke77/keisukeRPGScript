using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ItemSystem;

[RequireComponent(typeof(FlickerModel))]
[RequireComponent(typeof(Animator))]
public class enemyhp : hpcore
{
    public string enemyname;
    public UnityEvent events;
    public System.Action VanishEvent;
    public int exp;
    public itemdrops itemdrops;


    public override void OnDamage(int damage)
    {
        if (itemcurrent.instance != null)
        {
            Itemkind item = itemcurrent.instance.Itemkind;
            if (item != null)
            {
                item.Resitance -= damage / 10;
            }
        }
    }

    public override void damagestop()
    {
        if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {
            gameObject.GetComponentIfNotNull<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
    }

    public override void recover()
    {
        if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {
            gameObject.GetComponentIfNotNull<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public override void OnDeath()
    {
        
        if (anim != null)
        {
            keikei.delaycall(() => deathend(), 6f);
        }
        else
        {
            deathend();
        }

       }

    //アニメーションコントローラから実行

    public void deathend()
    {
        if (itemdrops != null)
        {
            itemdrops.itemdropers(gameObject);
        }
        VanishEvent += () =>
        {
            if (killer != null)
            {
                killer.acessdata().addexp(exp);
                killer.acessdata().nowquest?.enemykill(enemyname);
            }

            events.Invoke();
        };
        keikei.dissolvedeath(gameObject, VanishEvent);
    }
}
