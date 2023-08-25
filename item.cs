using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
<<<<<<< HEAD
using ItemSystem;
public class item : effect
{　
=======
public class item : effect
{
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
   public UnityEvent eve;
public float speedup=0.1f;
    public float effectpower;
    public float effectduration=5;
    public GameObject particle;
   public Itemkind Itemkind;
   public bool instanceexiqitem;
   public bool rotate;
<<<<<<< HEAD
  public bool itemvanish=true;
    public int money=0;
    bool once;
    public bool jump;
    public Vector3 force;
=======
  
    public int money=0;
    bool once;
    public bool jump;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    // Start is called before the first frame update
    void Start()
    {
        if (rotate)
        {
            keikei.rotate(gameObject);
        }
           }




public void execute(GameObject other){


   
if (!once)
{
    
once=true;

    if (eve!=null)
    {
        eve.Invoke();
    }
    if (speedup!=0)
    {
<<<<<<< HEAD
       gameObject.pclass().playerMovePram.movespeed+=speedup;
=======
        other.GetComponent<UnityChanControlScriptWithRgidBody>().movespeed+=speedup;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
     
       
    }
    if (money!=0)
    {
        other.GetComponent<datamanage>().addmoney(money);
    }
    
        if (particle != null)
        {
            Instantiate(particle,transform.position,Quaternion.identity);
       
        }
if (Itemkind!=null)
{ Itemkind.add(other);
    if (instanceexiqitem)
    {
<<<<<<< HEAD
other.pclass().itemmanage.itemhavingcheck(Itemkind)?.itemuses();
=======
other.pclass().itemmanage.itemhavingcheck(Itemkind).itemuses();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }
     
   
}
        if (jump)
        {
            jumpgive(other.gameObject,effectpower,effectduration);
        }
<<<<<<< HEAD
        if (force!=Vector3.zero)
        {
            other.PlayerAddForce(force);
        }
         
       if (itemvanish)
    {
     Destroy(gameObject);
    } 


    }
   
=======
         
      
    }
     Destroy(gameObject);
       
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }

void OnTriggerEnter(Collider obj)
{
   
        if (obj.proottag())
    {execute(obj.root());
        }
    
    
          }
<<<<<<< HEAD
void OnTriggerExit(Collider obj)
{
   once=false;
          }
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

}
