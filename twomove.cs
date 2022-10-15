using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twomove : MonoBehaviour
{Rigidbody2D rb;
public float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {if (rb)
    {
        rb.AddForce(keikei.GetDpad()*speed);
    }else
    {
          transform.Translate(keikei.GetDpad()*speed);
   
    }
       }
}
