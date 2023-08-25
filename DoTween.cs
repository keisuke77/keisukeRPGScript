using UnityEngine;
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class DoTween : MonoBehaviour
{
   public bool enablePlay;
   public DoTweenSeri DoTweenSeri;
   public Sequence seq;
   public KeyCode PlayButtton;
 [Button("Play", "Play")]
    public int a;
    public void Play()
    {
      seq= DoTweenSeri.Play(transform);
    }  
   
private void OnEnable() {
   if (enablePlay)
   {Play();
      
   }
}
public void Pause(){
   
 seq.Pause();
}
public void ReStart(){
    // トゥイーンの再開
    seq.Play();
}
private void Update() {
   if (PlayButtton.keydown())
   {
      Play();
   }
}
public void Repead(int num){
     seq.timeScale = num;  
}
}
=======
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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
