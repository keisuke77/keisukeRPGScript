using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;  // UniTaskのためのnamespaceを追加
using Unity.VisualScripting;

public static class AnimatorExtension
{
    public static void FloatTo(this Animator anim,string name,float n){
DOVirtual.Float(anim.GetFloat(name), n, 1, value =>{anim.SetFloat(name,value);});
    }
      public static bool GetTrigger(this Animator animator, string triggerName)
    {
        return animator.GetBool(triggerName);
    }

       public static async UniTask WaitForTransitionToEndAsync(this Animator animator)
    {
        while (animator.IsInTransition(0))
        {
            await UniTask.Yield();  // 次のフレームまで待機
        }
    }

     public static async void CrossFadeAnimation(this Animator animator,string name,int CrossFadeSmoothLevel)
    {
            animator.GetComponent<attackcore>().allofftriger();
     
           // 遷移が終わるまで待機
            await animator.WaitForTransitionToEndAsync();
            
               // 遷移が終わった後にCrossFadeを行う
            animator.CrossFadeInFixedTime(name, Time.deltaTime * CrossFadeSmoothLevel);
 
    }
    public static int GetHeaviestLayerIndex(this Animator animator)
    {
        int layerCount = animator.layerCount;
        float maxWeight = 0f;
        int heaviestLayerIndex = -1;

        for (int i = 1; i < layerCount; i++) // start from 1 to exclude layer 0
        {
            float currentWeight = animator.GetLayerWeight(i);
            if (currentWeight > maxWeight)
            {
                maxWeight = currentWeight;
                heaviestLayerIndex = i;
            }
        }

        return heaviestLayerIndex;
    }
}