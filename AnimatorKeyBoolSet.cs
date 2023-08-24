using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorKeyBoolSet : StateMachineBehaviour
{

   public AnimBoolName AnimBoolName;
 
keiinput keiinput;
  
  public float delay;
  float time;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {time+=Time.deltaTime;
        if (time>delay)
        {
              AnimBoolName.Update(keiinput);
        }
      

    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
        )
    {
            AnimBoolName.Anim=animator;
        keiinput=keiinput.Instance;

    

    }
       override public void OnStateExit(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
        )
    {
          time=0;
    }
}
