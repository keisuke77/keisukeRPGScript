using UnityEngine;
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
public void Play(Transform tra){
tra.DOLocalMove(move,speed).SetRelative(true).SetLoops(loopcount,looptype);
tra.DOLocalRotate(rot,speed).SetRelative(true).SetLoops(loopcount,looptype);
tra.DOScale(Scale,speed).SetRelative(true).SetLoops(loopcount,looptype);

}

}