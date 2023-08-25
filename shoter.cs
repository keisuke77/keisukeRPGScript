using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class shoter : MonoBehaviour{
    public GameObject shottarget;
    public float speed;
    private Rigidbody ballRigidbody;
    public bool auto;
    public GameObject lookingtarget;
      public Vector3 directionsousa;
      public Vector3 direction;
      public bool forwardforce;
    public float often=1;
float orioften;
public KeyCode GetKey;
 void Start(){ 
orioften=often;

if (auto)
        {
            InvokeRepeating("Shot",1f,often);
        }

 }
    
    void Update ()
    {  if (auto)
    {
        if (often!=orioften)
        {
            CancelInvoke("Shot");
  
        InvokeRepeating("Shot",1f,often);
          orioften=often;
        }
        
    }
        
           if (lookingtarget)
        {
            transform.LookAt(lookingtarget.transform.position);
        } 
        if(Input.GetKeyDown(GetKey)&&!auto)
        {
            Shot();
        }
        
    }
    
    private void Shot(){
         direction=directionsousa.normalized;
    
          GameObject bullet = Instantiate(shottarget,transform.position+ direction.normalized+transform.up*0.7f, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
         
                Rigidbody ballRigidbody = bullet.AddComponentIfnull<Rigidbody>();
        if (forwardforce)
        {
             ballRigidbody.AddForce(transform.forward * speed,ForceMode.Impulse);

        }else
        {
             ballRigidbody.AddForce(direction * speed,ForceMode.Impulse);

        }
         
        
    }
}
