using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humantriggerset : StateMachineBehaviour
{
public int damagevalue;
public int forcepower;
public bool charge;
    public bodypart bodypart;

    
     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   animator.GetComponent<triggeronoff>().obj=bodypart.Getbodypart().GetComponentIfNotNull<Collider>();
   
   
   
  if (charge)
  {
      
animator.GetComponent<triggeronoff>().obj.gameObject.GetComponent<attackunitychan>().damagevalue=(int)(animator.GetFloat("chargepower")*10);

animator.GetComponent<triggeronoff>().obj.gameObject.GetComponent<attackunitychan>().forcepower=(int)(animator.GetFloat("chargepower")*5);
 
  }else
  {
      
if (damagevalue!=0)
{
    
animator.GetComponent<triggeronoff>().obj.gameObject.GetComponent<attackunitychan>().damagevalue=damagevalue; 

}
     }

animator.GetComponent<triggeronoff>().obj.gameObject.GetComponent<attackunitychan>().forcepower=forcepower; 

    }}