using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spawnarea : MonoBehaviour
{


    public GameObject spawnobj;
    public GameObject spawnparticle;
    public bool onecvanish=true;
    public UnityEvent events;
    bool once;
    public enemysSet enemysSet;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
    }
void OnTriggerEnter(Collider other)
{if (other.gameObject.tag=="Player"&&!once)
{once=true;
keikei.message.SetMessagePanel(message,true);


if (spawnobj!=null)
{ 
    var obj= keikei.mobspawn(spawnobj,transform,spawnparticle,5f);
        obj.deatheventset(events);

}
  
if (enemysSet!=null)
{
   var objs= enemysSet.spawn(transform);
foreach (var item in objs)
{
     
item.deatheventset(events);
}
}
    if (onecvanish)
    {
        Destroy(gameObject);
    }
    
}
    
}
}
