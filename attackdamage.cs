using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackdamage : StateMachineBehaviour
{
    public int damagevalue=5;
    public int a=0;
    public int forcepower;
   
     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    animator.GetComponent<triggeronoff>().obj.gameObject.GetComponent<attackunitychan>().damagevalue=damagevalue; 
 animator.GetComponent<triggeronoff>().obj.gameObject.GetComponent<attackunitychan>().forcepower=forcepower; 

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a tenemransition ends and the state machine finishes evaluating this state
   

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
