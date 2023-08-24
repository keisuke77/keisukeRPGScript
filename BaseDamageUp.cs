using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseDamageUp : StateMachineBehaviour
{
    attackcore Attackcore;
    public int basedamagevalue;
    public float baseforcepower;
    
     int Defaultbasedamagevalue;
     float Defaultbaseforcepower;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        Attackcore.basedamagevalue=Defaultbasedamagevalue;
        Attackcore.baseforcepower=Defaultbaseforcepower;
    Attackcore.allofftriger();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
    )
    {
if (Attackcore==null)
{
    Attackcore=animator.GetComponent<attackcore>();
}
Defaultbasedamagevalue =Attackcore.basedamagevalue;
    Defaultbaseforcepower=  Attackcore.baseforcepower;
      
  Attackcore.basedamagevalue=basedamagevalue;
        Attackcore.baseforcepower=baseforcepower;
 
    }
}
