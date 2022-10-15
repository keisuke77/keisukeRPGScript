using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atractcameras : StateMachineBehaviour
{

    public float cameradistance;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

if (animator.gameObject.ptag())
{
    animator.GetComponent<playerclass>().AutoRotateCamera.lerpatractcamera(animator.transform,cameradistance==0?-9.8f:cameradistance);
  
}else
{
     foreach (var obj in keikei.AutoRotateCameraAll)
        { obj.lerpatractcamera(animator.transform,cameradistance==0?-9.8f:cameradistance);
  
             }
}

      }


  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
if (animator.gameObject.ptag())
{
    animator.GetComponent<playerclass>().AutoRotateCamera.atractend();
}else{
    
       foreach (var obj in keikei.AutoRotateCameraAll)
        { obj.atractend();
             }
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
