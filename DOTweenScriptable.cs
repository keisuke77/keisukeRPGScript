using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening; 
[CreateAssetMenu(fileName = "DOTweenScriptable", menuName = "")]
public class DOTweenScriptable : ScriptableObject
{
     public Vector3 move;
    public Vector3 rot;
    public Vector3 Scale;
    public float speed;
    public bool autoStart;
public LoopType looptype;
   public int loopcount;
   public bool TweeningPlay;
   public bool reverse;
   public AnimationCurve Curve;/**< Tweenのイージングのカーブ*/
   
  public List<Tweener> twins;
 public void Play(Transform tra){
   twins=new List<Tweener>();
   if (TweeningPlay||!DOTween.IsTweening(tra))
   {
twins.Add(tra.DOLocalMove(move,speed).SetRelative(true).SetLoops(loopcount,looptype).SetEase(Curve));

twins.Add(tra.DOLocalRotate(rot,speed).SetRelative(true).SetLoops(loopcount,looptype).SetEase(Curve));
twins.Add(tra.DOScale(Scale,speed).SetRelative(true).SetLoops(loopcount,looptype).SetEase(Curve));
if (reverse)
{foreach (var item in twins)
{item.Complete();
   item.PlayBackwards();
}
   
}
   }
}


}