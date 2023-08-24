using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navmeshstop : StateMachineBehaviour
{
  public float speed;
  float a;
  public UnityEngine.AI.NavMeshAgent nav;
   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nav= animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
     
           a=nav.speed;
     nav.enabled=false;
       keikei.delaycall(()=>nav.enabled=true,2f);
        nav.speed=speed;
    } 
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nav.speed=speed;
    } 
    
    
    
    
      override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
     nav.enabled=true;
       
       nav.speed=a;
    } 
    
    // OnStateUpdate hissatuis called on each Update frame between OnStateEnter and OnStateExit callbacks
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
