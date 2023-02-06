using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideforce : MonoBehaviour
{
    public float power;

    public bool bound;
    // Start is called before the first frame update
   void OnCollisionEnter(Collision col)
    {Rigidbody rb=GetComponent<Rigidbody>();
        if (rb.velocity!=Vector3.zero||bound)
    {
Vector3 force;
        if (bound)
        {
             force =(col.transform.position-transform.position)*power;
 
 
        }else
        {
          force =(col.transform.position-transform.position)*rb.velocity.sqrMagnitude*power;
 

        }
      
        
col.gameObject.PlayerAddForce(force);
        
    }  
}}