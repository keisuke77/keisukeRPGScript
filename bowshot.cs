using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class bowshot : MonoBehaviour{
    public GameObject shottarget;
    public float speed=5;
    
      private Rigidbody ballRigidbody;
    public bool auto;
    public bool automuch;
    public GameObject aite;
    public bool look;
     public bool Boomerang;
     public Vector3 offsetcontroll;
      public int basepower;
    public float often=1;
    public bool spacekeyshot;
    public bool danyaku;
    public bool hitdespawn;
float orioften;
public bool onceshot;
public int damagevalue;
public int test ;
public bool enemydamage;
public Transform shoterpos;
 void Start(){ 
     if (shoterpos==null)
     {
         shoterpos=transform;
     }
orioften=often;
if (auto)
        {
            InvokeRepeating("Shot",1f,often);
        }

 }
   

    void Update ()
    {  test=damagevalue;
    if (damagevalue>200)
    {
        Shot();
        damagevalue=0;
    }
        if (auto)
    {
        if (often!=orioften)
        {
            CancelInvoke("Shot");
  
        InvokeRepeating("Shot",1f,often);
          orioften=often;
        }
        
    }
        
           if (look)
        {
           shoterpos.LookAt(aite.transform.position);
        } 

        if(Input.GetKeyDown("space")&&!auto&&spacekeyshot)
        { 
            keikei.Shot(gameObject,shottarget,damagevalue,danyaku,speed);
        }
        
    }
    
    public void Shot(){
        
          GameObject bullet = Instantiate(shottarget,shoterpos.position+shoterpos.forward+offsetcontroll, gameObject.transform.root.gameObject.transform.rotation);
         damagevalue=Mathf.Clamp(damagevalue,1,200);
        if (danyaku)
        {
             bullet.AddComponent(typeof(rigidexplosion));
        }
        
        bullet.AddComponent(typeof(Rigidbody));
      
       
       
                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                if (enemydamage)
                { 
                    bullet.AddComponent(typeof(attackunitychan));
       
                     var a= bullet.GetComponent<attackunitychan>();
             a.damagevalue=(int)((damagevalue/3)+basepower);
             if (Boomerang)
             {
                 bullet.AddComponent(typeof(Boomerang));
             }else
             {
                
 ballRigidbody.AddForce(shoterpos.root.gameObject.transform.forward*speed*damagevalue,ForceMode.Impulse);
                
             }
             keikei.colliderset(bullet);
                
                }else
                {if (automuch)
                {
                    bullet.transform.forward=gameObject.NearserchTag("Player").transform.forward;
                   
                }
                     bullet.AddComponent(typeof(playerdamage));
       
                     var b= bullet.GetComponent<playerdamage>();
             b.damagevalue=damagevalue;
             if (hitdespawn)
             {
                 b.hitdespawn=true;
             }
              if (Boomerang)
             {
                 bullet.AddComponent(typeof(Boomerang));
             }else
             {
                
 ballRigidbody.AddForce(shoterpos.root.gameObject.transform.forward*speed,ForceMode.Impulse);
             }
                }
                   
          if (onceshot)
          {
           gameObject.SetActive(false);
          }
        
    }
}
