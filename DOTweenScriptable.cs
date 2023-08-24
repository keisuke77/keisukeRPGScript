using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[CreateAssetMenu(fileName = "DOTweenScriptable", menuName = "")]
public class DOTweenScriptable : ScriptableObject
{
   
    public DiretionEnum Diretion;
    public float DiretionPower;
    public Vector3 move;
    public Vector3 rot;
    public Vector3 Scale;
    public float JumpPower = 0;
    public float speed;
    public LoopType looptype;
    public int loopcount;
    public bool TweeningPlay;
    public AnimationCurve Curve; 

    /**< Tweenのイージングのカーブ*/



    public Sequence GetSequence(Transform tra)
    {
        List<Tweener> twins = GetTweernr(tra);
        Sequence Sequence = DOTween.Sequence();
        foreach (var item in twins)
        {
            Sequence.Join(item);
        }
        return Sequence;
    }

    public List<Tweener> GetTweernr(Transform tra)
    {
        List<Tweener> twins = new List<Tweener>();
        if (TweeningPlay || !DOTween.IsTweening(tra))
        {

                    
if (move!=Vector3.zero||DiretionPower!=0)
{
            twins.Add(
                tra.DOLocalMove(move+(tra.GetDirection(Diretion)*DiretionPower), speed)
                    .SetRelative(true)
                    .SetLoops(loopcount, looptype)
                    .SetEase(Curve)
            );
}

if (rot!=Vector3.zero)
{
       twins.Add(
                tra.DOLocalRotate(rot, speed)
                    .SetRelative(true)
                    .SetLoops(loopcount, looptype)
                    .SetEase(Curve)
            );
}
         if (Scale!=Vector3.zero)
         {
              twins.Add(
                tra.DOScale(Scale, speed)
                    .SetRelative(true)
                    .SetLoops(loopcount, looptype)
                    .SetEase(Curve)
            );
         }
          
        }
        return twins;
    }
}
