using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.Events;
public enum SequenceMethod
{
    Append,
    Join
}

[System.Serializable]
public class DoTweenSeri
{
    [System.Serializable]
    public class DOTweenSequence
    {
        public SequenceMethod SequenceMethod;

        public float Speed=1;
        public DOTweenScriptable DOTweenScriptable;
        public UnityEvent Event;
    }
 public UnityEvent StartEvent;
    public List<DOTweenSequence> DOTweenSequences;

    

    public Sequence Play(Transform tra)
    {
        Sequence Sequence = DOTween.Sequence();
        foreach (var item in DOTweenSequences)
        {
            Sequence temp = item.DOTweenScriptable.GetSequence(tra);
            switch (item.SequenceMethod)
            {
                case SequenceMethod.Append:
                    Sequence.Append(temp);
                    break;

                case SequenceMethod.Join:
                    Sequence.Join(temp);
                    break;
                default:
break;
            }
              Sequence.AppendCallback(() =>
    {
       item.Event.Invoke();
    }); 
    
    Sequence.timeScale = item.Speed;  
  
        }
        StartEvent.Invoke();
          return Sequence;
    }
}
