using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class AnimotorBlendAnimationKey
{
    public KeyCode key;
    public AnimationClip clip;
    public string changeabletag="Idle";
    public string name;
    public InsertAnimation InsertAnimation;

public void Blend(){
    if (key.keydown())
        {    if (InsertAnimation.animator.GetCurrentAnimatorStateInfo(0).IsTag(changeabletag)){
               InsertAnimation.Plays(clip);
            }
        }

}


}
[RequireComponent(typeof(InsertAnimation))]
public class simpleanimationskey : MonoBehaviour {
    [Header("SimpleAnimation is needed")]

    public AnimotorBlendAnimationKey[] AnimotorBlendAnimationKeys;

    private void Start() {
        
        foreach (var item in AnimotorBlendAnimationKeys)
        {TryGetComponent(out item.InsertAnimation);
           
                   }
        }


    private void Update() {

        foreach (var item in AnimotorBlendAnimationKeys){
        
           item.Blend();
      
        }
         
    }
    

}