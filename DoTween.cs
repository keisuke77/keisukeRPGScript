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
    DOTweenScriptable.Play(transform);
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