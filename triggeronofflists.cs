using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeronofflists : StateMachineBehaviour
{public MyEnumType timing;
public int num;
    public enum MyEnumType
    {
        enter,exit
    }
  public bool switchs=true;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {if (timing!=MyEnumType.enter)
    {
        return;
    }
       animator.GetComponent<trrigeronofflist>().triger(num,switchs);
    }
override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {if (timing!=MyEnumType.exit)
    {
        return;
    }
      animator.GetComponent<trrigeronofflist>().triger(num,switchs);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
