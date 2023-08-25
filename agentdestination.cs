using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;using UnityEngine.AI;

public class agentdestination : StateMachineBehaviour
{
    public bool random;
    public Vector3 controll;
    public float randomdistance;
    public bool end;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
    )
    {
        animator.GetComponent<NavMeshAgent>().destination =
            animator.transform.position
            + controll
            + (random ? ((keikei.randomvectornotY()) * randomdistance) : Vector3.zero);
    }
=======
using UnityEngine;

public class agentdestination : StateMachineBehaviour
{

public bool random;
public Vector3 controll;
public float randomdistance;
public bool end;


 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
      animator.GetComponent<navchaise>().agent.destination=animator.transform.position+controll+(random?((keikei.randomvectornotY())*randomdistance):Vector3.zero);
    }
    
   
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
<<<<<<< HEAD
        if (end)
        {
            animator.GetComponent<navchaise>().newposition();
        }
=======
     if (end)
     {
          animator.GetComponent<navchaise>().newposition();
 
     }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
<<<<<<< HEAD
    //
=======
    //    
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
