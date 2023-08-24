using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humantriggerset : StateMachineBehaviour
{

    [Header("キャラクターチェンジがついてるもののみ")]

   private bool charge;
   private bodypart bodypart;
   private float ColliderSize=0.1f;
   private string name;
    public int Layer;
    public DamageInfo damageInfo;
    public AttackPram attackPram;

public void Load(){
 if (attackPram != null)
    {
        damageInfo.damagValue = attackPram.damagevalue;
        damageInfo.forceValue = attackPram.forcepower;
        charge = attackPram.charge;
        bodypart = attackPram.bodypart;
        ColliderSize = attackPram.ColliderSize;
        name = attackPram.name;
    }

}
public void attackerChange(AttackPram newAttackParams)
{
    if (newAttackParams != null)
    {
        attackPram = newAttackParams; // Assign new AttackPram
        Load(); // Load the properties from the new AttackPram into the humantriggerset
    }
  
}


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {  
        var attackcore=animator.GetComponent<attackcore>();  
    attackcore.allofftriger();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
    )
    {
        Load();
        if (animator.GetHeaviestLayerIndex()!=Layer)
        {
            return;
        }

        var attackcore=animator.gameObject.GetComponent<attackcore>()as attackcore;
    
        if (bodypart!=bodypart.no)
        {
             attackcore.CurrentAttackPart=new AttackPart(bodypart.Getbodypart(animator.gameObject.root()),name,ColliderSize);
             attackcore.AddAtackPartCurrent();
        }
       
        
        if (charge)
        {
           attackcore.CurrentAttackPart.damageInfo.damagValue = (int)(animator.GetFloat("chargepower") * 10);
           attackcore.CurrentAttackPart.damageInfo.forceValue = (int)(animator.GetFloat("chargepower") * 5);
        }
        else
        {
        attackcore.CurrentAttackPart.damageInfo = damageInfo;
            
        }

    }
}
