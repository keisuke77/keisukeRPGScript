using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{public bool relatemass;public bool forwardforce;
    Rigidbody rb;
    public float power =10f;
    public Vector3 direction ;
    
public bool randomdirection;
public ForceMode mode;

public Vector3 force(){
 Vector3 forces;
  if (relatemass)
    { 
        forces=direction*power*rb.mass;
   
    }else
    {
         forces=direction*power;
   
    }
    return forces;
}
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
        if (forwardforce)
   {
      direction=transform.forward; 
   }
   if (randomdirection)
   {
       direction=keikei.randomvector();

   }

    if (mode==ForceMode.Impulse)
    {
         rb.AddForce(force(),ForceMode.Impulse);
 
    }
    }

void FixedUpdate()
{if (Mathf.Approximately(Time.timeScale, 0f)) {
		return;
	}
   
   
  
   if (mode==ForceMode.Force)
    {
        rb.AddForce(force(),ForceMode.Force);
 
    }
   
}
    // Update is called once per frame
    
}
