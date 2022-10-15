using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public string tags="breaker";
public float power=10;
public GameObject particle;
public itemdrop itemdrop;
public bool zerovelocitybreake;
public bool collidebreak=true;
bool once;
 

void Update()
{
    
        if (zerovelocitybreake)
    {
        if (GetComponent<Rigidbody>().velocity==Vector3.zero)
        {
            breaken();
        }
    }
}



void OnCollisionEnter(Collision collisionInfo)
{
    if (collisionInfo.gameObject.tag==tags&&collidebreak)
    {
        breaken();
    }
     
}
void OnTriggerEnter(Collider collisionInfo)
{
    if (collisionInfo.gameObject.tag==tags&&collidebreak)
    {
        breaken();
    }
     
}


public void breaken(){



    if (once)
    {
        return;
    }
    once=true;

   

if (particle!=null)
{
Instantiate(particle,transform.position,Quaternion.identity);
}
   
 gameObject.destroyObject(power);
   itemdrop?.itemappenddrop(gameObject);
}



}
