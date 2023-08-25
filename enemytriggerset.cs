using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytriggerset : StateMachineBehaviour
{
public int damagevalue;
public float forcepower;
    public int[] triggernumber;
    enemyattack enemyattack;
     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
animator.GetComponent<trrigeronofflist>().num=triggernumber;
foreach (var item in triggernumber)
{
    
  enemyattack= animator.GetComponent<trrigeronofflist>().objs[item].gameObject.GetComponent<enemyattack>();
  enemyattack.damagevalue=damagevalue; 
   enemyattack.forcepower=forcepower;
   
   
}
   
    }}