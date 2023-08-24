using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidexplosion : MonoBehaviour
{Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

void OnCollisionEnter(Collision collisionInfo)
{
     keikei.deathexplosion(gameObject);
  
}
    // Update is called once per frame
    void Update()
    {if (rb.IsSleeping())
    {
        keikei.deathexplosion(gameObject);
    }
        
    }
}
