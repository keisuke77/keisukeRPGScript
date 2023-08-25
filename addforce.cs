using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
<<<<<<< HEAD
{
    public bool relatemass;
    public bool forwardforce;
    Rigidbody rb;
    public float power = 10f;
    public Vector3 direction;
    [Header("forcemodeの時のみ")]
    public bool repeat;

[Button("AddForce","AddForce")]
    public int btn;
    public bool randomdirection;
    public ForceMode mode;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce()
    {
        if (forwardforce)
        {
            direction = transform.forward;
        }
        if (randomdirection)
        {
            direction = keikei.randomvector();
        }
        if (relatemass)
        {
            direction *= rb.mass;
        }


            rb.AddForce(direction * power, mode);
        
    }

    void FixedUpdate()
    {
        if (!repeat)
        {
            return;
        }
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (mode == ForceMode.Force)
        {
            AddForce();
        }
    }
    // Update is called once per frame
=======
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
    
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
