using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ondamage : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

animator.GetComponent<hp>().nodamage=false;

animator.GetComponent<enemyhp>().nodamage=false;


}}