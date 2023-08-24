using UnityEngine;

public class AnimSpeedChangeState : MonoBehaviour {

      
[Header("AnimSpeedパラメーター調節")]
public Animator anim;
[Header("走るときの速さ"),Range(0,10)]
public float runSpeed=1;
[Header("歩きのときの速さ"),Range(0,10)]
public float walkSpeed=1;
[Header("たちのときの速さ"),Range(0,10)]
public float idleSpeed=4;
  void Update() {
      if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
      {
                if ( anim.GetFloat("speed")>1.3f)
        {
            anim.SetFloat("AnimSpeed",runSpeed);
        }else if ( anim.GetFloat("speed")>0.3f)
        {
              anim.SetFloat("AnimSpeed",walkSpeed);
     
        }else
        {
              anim.SetFloat("AnimSpeed",idleSpeed);
     
        }
      }
    
    }
}