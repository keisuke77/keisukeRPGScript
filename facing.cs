using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facing : MonoBehaviour
{
    public GameObject target;
    public bool reverse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (reverse)
    {
        this.transform.LookAt(target.transform);
   this.transform.rotation =this.transform.rotation ;
    }else{
        this.transform.LookAt(target.transform);
   
    }
         
    }
}
