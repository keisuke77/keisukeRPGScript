using UnityEngine;
using UnityEngine.Events;

public class playercollide : animatorSET
{
    public UnityEvent enterevents;public UnityEvent endevents;
    public float delaytime;
    
public void Play(GameObject obj){
keikei.delaycall(()=>delayPlay(obj),delaytime);
}      
public void delayPlay(GameObject obj){
if (obj.proottag())
{
   enterevents?.Invoke();
   SetBool(obj);
   SetTrigger(obj);
}
}    


public void endPlay(GameObject obj){
if (obj.proottag())
{
   endevents?.Invoke();}
}



void OnCollisionEnter(Collision collisionInfo)
{


   Play(collisionInfo.gameObject);
}
void OnCollisionExit(Collision collisionInfo)
{endPlay(collisionInfo.gameObject);
}  

void OnTriggerEnter(Collider collisionInfo)
{Play(collisionInfo.gameObject);
}
void OnTriggerExit(Collider collisionInfo)
{endPlay(collisionInfo.gameObject);
}
}