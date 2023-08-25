using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force2 : MonoBehaviour
{
   public float power=2;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }
private void FixedUpdate()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * power * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void fiUpdate()
    {
        
    }
}
