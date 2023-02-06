using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animCancellCollider : MonoBehaviour
{public int test;
    public string tags;
    public bool triger;
    public bool collide;
    public bool hascollision=false;
    // Start is called before the first frame update


    void Update()
    {
        test++;
        if (test>8)
        {
            hascollision=false;
        }
    }
void OnTriggerStay(Collider other)
{if (!triger)
 return;
 test=0;



    if (other.gameObject.tag==tags)
        {
           
	gameObject.root().GetComponent<Animator>().Play("Idle");

    }
}

void OnTriggerExit(Collider other)
{if (!triger)return;

 
     
}


    void OnCollisionStay(Collision other)
    {


if (!collide) return;

test=0;
        if (tags=="")
        {
             hascollision=true;
        }
        
        if (other.gameObject.tag==tags)
    {
        hascollision=true;
    }
          }

          void OnCollisionExit(Collision other)
          {if (!collide)
{
    return;
}
               if (tags=="")
        {
             hascollision=false;
        }
        
        if (other.gameObject.tag==tags)
    {
        hascollision=false;
    }
          }
    // Update is called once per frame

}
