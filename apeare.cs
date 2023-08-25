using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apeare : MonoBehaviour
{ Transform playertrans;
Transform mytrans;
 public Animation anim;
 public Animation endanim;
 Animator animator;
 bool once;
    // Start is called before the first frame update
    void Start()
    {mytrans=transform;
        playertrans=gameObject.NearserchTag("Player").root().transform;
        animator=GetComponent<Animator>();
        anim.Play();
    }
    
    // Update is called once per frame
    void Update()
    {Vector3 targetpos=playertrans.position+(playertrans.forward*5);
        mytrans.position=Vector3.Lerp(mytrans.position,targetpos,0.1f);
        if (Mathf.Approximately((mytrans.position-targetpos).sqrMagnitude,0))
        {
            if (!once)
            {endanim.Play();
                once=true;
            }
        }
       
    }
}
