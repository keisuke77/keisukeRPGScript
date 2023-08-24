using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collideevent : MonoBehaviour
{
    
    [System.Serializable]
     public class collideevents
    {
        
    public MyEnumType timing;
    public UnityEvent events;
    public string tag="Untagged";
    
    }
public GameObject debug;

    public collideevents[] events;
    public enum MyEnumType
    {
        enter,
        stay,
        exit
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


public void execute(MyEnumType enums,Collision obj){

    debug=obj.gameObject;
foreach (var item in events)
{
     if(item.timing==enums)
        {
            if (obj.gameObject.CompareTag(item.tag)){
                          item.events.Invoke();
          }
}
}

}

public void execute(MyEnumType enums,Collider obj){

    debug=obj.gameObject;
foreach (var item in events)
{
     if(item.timing==enums)
        {
            if (obj.gameObject.CompareTag(item.tag)){
                          item.events.Invoke();
          }
}
}

}
void OnCollisionEnter(Collision collisionInfo)
{ execute(MyEnumType.enter,collisionInfo);
      
}

void OnCollisionExit(Collision collisionInfo)
{
  execute(MyEnumType.exit,collisionInfo);
        
}
void OnCollisionStay(Collision collisionInfo)
{
   execute(MyEnumType.stay,collisionInfo);
}
void OnTriggerEnter(Collider collisionInfo)
{ execute(MyEnumType.enter,collisionInfo);
      
}

void OnTriggerExit(Collider collisionInfo)
{
  execute(MyEnumType.exit,collisionInfo);
        
}
void OntriggerStay(Collider collisionInfo)
{
   execute(MyEnumType.stay,collisionInfo);
}
  
}
