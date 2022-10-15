using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class parametaredit : StateMachineBehaviour
{
   public enum MyEnumType
    {
        enter,exit
    }
    [System.Serializable]
   public class parameta
    {
        
  public string motionboolname="ScrewKick";
    public bool setbool=false;
    public float setfloat;
public MyEnumType timing;
 public float delate;
    }

    public parameta[] parametas;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
public void setbool(Animator anim,string motionboolname,bool bools){

 anim.GetComponent<Animator>().SetBool(motionboolname,bools);
    

}
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        foreach (var item in parametas)
        { if (item.timing==MyEnumType.exit)
    {
            if (item.delate==0)
    {
        animator.SetBool(item.motionboolname,item.setbool);
  animator.SetFloat(item.motionboolname,item.setfloat);
  
    }else
    {
         DOVirtual.DelayedCall(item.delate, () => {
 
  animator.SetBool(item.motionboolname,item.setbool);
  animator.SetFloat(item.motionboolname,item.setfloat);
  
  });   
    }}
         }
    }
            override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { foreach (var item in parametas)
        {


            
            if (item.timing==MyEnumType.enter)
    {if (item.delate==0)
    {
        animator.SetBool(item.motionboolname,item.setbool);
   animator.SetFloat(item.motionboolname,item.setfloat);

    }else
    {
         DOVirtual.DelayedCall(item.delate, () => {
 
  animator.SetBool(item.motionboolname,item.setbool);
   animator.SetFloat(item.motionboolname,item.setfloat);

  });   
    }
   
  
  
   }
       
        }  }
   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
