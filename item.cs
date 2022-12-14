using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class item : effect
{
   public UnityEvent eve;
public float speedup=0.1f;
    public float effectpower;
    public float effectduration=5;
    public GameObject particle;
   public Itemkind Itemkind;
   public bool instanceexiqitem;
   public bool rotate;
  public bool itemvanish=true;
    public int money=0;
    bool once;
    public bool jump;
    public Vector3 force;
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
        other.GetComponent<UnityChanControlScriptWithRgidBody>().movespeed+=speedup;
     
       
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
other.pclass().itemmanage.itemhavingcheck(Itemkind).itemuses();
    }
     
   
}
        if (jump)
        {
            jumpgive(other.gameObject,effectpower,effectduration);
        }
        if (force!=Vector3.zero)
        {
            other.PlayerAddForce(force);
        }
         
       if (itemvanish)
    {
     Destroy(gameObject);
    } 


    }
   
    }

void OnTriggerEnter(Collider obj)
{
   
        if (obj.proottag())
    {execute(obj.root());
        }
    
    
          }
void OnTriggerExit(Collider obj)
{
   once=false;
          }

}
