using UnityEngine;
using UnityEngine.Events;

public class playercollide : MonoBehaviour
{
    public UnityEvent enterevents;public UnityEvent endevents;
void OnCollisionEnter(Collision collisionInfo)
{if (collisionInfo.proottag())
{
   enterevents.Invoke();
}}
void OnCollisionExit(Collision collisionInfo)
{if (collisionInfo.proottag())
{
   endevents.Invoke();}
}
}