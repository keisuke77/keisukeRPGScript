using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidfix : MonoBehaviour
{
    public ground ground;
    private Rigidbody rigid;
    public bool x;public bool y;public bool z;public bool rx;public bool ry;
public bool rz;
public bool all;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if (x)
       {
           rigid.constraints = RigidbodyConstraints.FreezePositionX;
       } if (y)
       {
           rigid.constraints = RigidbodyConstraints.FreezePositionY;
       }
        if (z)
       {
           rigid.constraints = RigidbodyConstraints.FreezePositionZ;
       } if (rx)
       {
           rigid.constraints = RigidbodyConstraints.FreezeRotationX;
       }if (ry)
       {
           rigid.constraints = RigidbodyConstraints.FreezeRotationY;
       }if (rz)
       {
           rigid.constraints = RigidbodyConstraints.FreezeRotationZ;
       }if (all)
       {
           rigid.constraints = RigidbodyConstraints.FreezeRotationZ|RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ;
       }
        if (ground.Grounded)
        {
            all=true;
        }
    }
}
