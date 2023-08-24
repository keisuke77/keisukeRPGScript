using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navmeshspeedchange : StateMachineBehaviour
{
public float speed;
 float orispeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       var nav= animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
       orispeed=nav.speed;
       nav.speed=speed;
    } override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       var nav= animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
       
       nav.speed=orispeed;
    } 
}