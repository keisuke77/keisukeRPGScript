using UnityEngine;
using DG.Tweening;

public static class AnimatorExtension
{
    public static void FloatTo(this Animator anim,string name,float n){


DOVirtual.Float(anim.GetFloat(name), n, 1, value =>{anim.SetFloat(name,value);});
    }
}