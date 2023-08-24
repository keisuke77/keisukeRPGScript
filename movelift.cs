using UnityEngine;
using DG.Tweening;
public class movelift : MonoBehaviour
{ 
    public Vector3 direction;
    public float speed;
   public int loopcount;
   public LoopType LoopType;
  
   public AnimationCurve constant ;
public Ease type;
    void Start()
    {
        gameObject.transform.DOMove(direction, speed).SetRelative(true).SetEase(type).SetLoops(loopcount, LoopType);

      
    }
}