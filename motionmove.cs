using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionmove : StateMachineBehaviour
{
    bool once=false; 
    public enum MyEnumType
    {
        enter,
        stay,
        exit
    }
    public float movepower=1;
    public MyEnumType timing;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (timing==MyEnumType.enter)
        {
             animator.transform.position+=animator.transform.up*movepower;
 
        }
        once=false;
          }
          
          override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timing==MyEnumType.stay)
        {
            if(once)
return;
once =true;
             animator.transform.position+=animator.transform.up*movepower;
 
        }
          }
          
          override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (timing==MyEnumType.exit)
        {
             animator.transform.position+=animator.transform.up*movepower;
 
        }
        
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
