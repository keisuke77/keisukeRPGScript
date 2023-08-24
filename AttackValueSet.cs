using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackValueSet : StateMachineBehaviour
{
    public int damagevalue;
    public float forcepower;
    public string name;
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { var attackcore=animator.GetComponent<attackcore>();  
    attackcore.CurrentAttackPart.Off();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
    )
    {
        var attackcore=animator.GetComponent<attackcore>();
        
        attackcore.CurrentAttackPartSet(name);
        attackcore.baseforcepower=forcepower;
        attackcore.basedamagevalue=damagevalue;
    }
}
