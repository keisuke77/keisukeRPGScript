using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalebig : MonoBehaviour
{ public Vector3 defaultScale = Vector3.zero;
public float bigspeed =1.01f;
public float maxscale=5;
private float a=1;
public bool enddestroy=true;
public bool xfix=false;public bool yfix=false;public bool zfix=false;
    void Start () 
    {
        defaultScale = transform.localScale;
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {if (a<maxscale)
    {

        a*=bigspeed;
        transform.localScale*=bigspeed;
  if (xfix)
  {Vector3 x= transform.localScale;
  x.x=defaultScale.x;

      transform.localScale=x;
  }if (yfix)
  {Vector3 y= transform.localScale;
   y.y=defaultScale.y;
      transform.localScale=y;
  }if (zfix)
  {Vector3 z= transform.localScale;
   z.z=defaultScale.z;
      transform.localScale=z;
  }
    }else
    {if (enddestroy)
    {
         Destroy(this.gameObject);
   
    }
        } 
     }
}
