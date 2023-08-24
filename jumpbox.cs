using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpbox : MonoBehaviour
{
    GameObject player;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnCollisionEnter(Collision collisionInfo)
{if (collisionInfo.gameObject.tag=="jumpbox")
{
    jump();
}
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag=="Player")
{
    player=collisionInfo.gameObject;
}
    }
    void OnCollisionExit(Collision collisionInfo)
    {
         if (collisionInfo.gameObject.tag=="Player")
{
    player=null;
}
    }
    void jump(){
        if (player!=null)
        {
            
player.GetComponent<Rigidbody>().AddForce(Vector3.up*power,ForceMode.Impulse);

        }
    }
   
}
