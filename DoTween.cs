using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    public DOTweenScriptable DOTweenScriptable;
     Vector3 move;
     Vector3 rot;
    Vector3  Scale;
    float    speed;
     bool    autoStart;

void Play(){
transform.DOLocalMove(move,speed).SetRelative(true);
transform.DOLocalRotate(rot,speed).SetRelative(true);
transform.DOScale(Scale,speed).SetRelative(true);

}
  
    void Start()
    {
        move =     DOTweenScriptable.move ;
        rot =    DOTweenScriptable.rot ;
        Scale=     DOTweenScriptable.Scale;
        speed=     DOTweenScriptable.speed;
        autoStart  =   DOTweenScriptable.autoStart;


        if (autoStart)
        {Play();
            
        }
    }
}