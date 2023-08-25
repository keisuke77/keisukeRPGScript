using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnobject : StateMachineBehaviour
{ public enum MyEnumType
    {
        enter,
        stay,
        exit
    }
   public GameObject obj;
    public MyEnumType timing;

<<<<<<< HEAD
=======
public enum bodypart
{
    righthand,lefthand,rightfoot,leftfoot,weapons,defaults
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

public bodypart bodyparts;

    
<<<<<<< HEAD
=======
public GameObject part(Animator animator){
switch (bodyparts)
{
    case bodypart.righthand:

  return animator.GetComponent<charactorchange>().GetRightHand().gameObject;
        break;
  case bodypart.lefthand:

  return animator.GetComponent<charactorchange>().GetLeftHand().gameObject;
  break;   case bodypart.rightfoot:

  return animator.GetComponent<charactorchange>().GetRightFoot().gameObject;
        break;
        case bodypart.leftfoot:
  return animator.GetComponent<charactorchange>().GetLeftFoot().gameObject;
     break;
   case bodypart.weapons:
 return keikei.player.GetComponent<objectchange>().Getobj().gameObject;  
   break;case bodypart.defaults:
 return animator.gameObject;  
   break;
    default:
        break;
}
return null;
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (timing==MyEnumType.enter)
<<<<<<< HEAD
        {Instantiate(obj,bodyparts.Getbodypart(animator.gameObject).transform.position,Quaternion.identity);
=======
        {Instantiate(obj,part(animator).transform.position,Quaternion.identity);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
          }
    }
          override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timing==MyEnumType.stay)
        {
<<<<<<< HEAD
           Instantiate(obj,bodyparts.Getbodypart(animator.gameObject).transform.position,Quaternion.identity);
=======
           Instantiate(obj,part(animator).transform.position,Quaternion.identity);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        
        }
        
          }
          
          override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (timing==MyEnumType.exit)
        {
<<<<<<< HEAD
            Instantiate(obj,bodyparts.Getbodypart(animator.gameObject).transform.position,Quaternion.identity);
=======
            Instantiate(obj,part(animator).transform.position,Quaternion.identity);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        
        }
        
          }
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
