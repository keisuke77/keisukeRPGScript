using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackunitychan : MonoBehaviour
{
    
    public collcheck collcheck; 
Rigidbody rb ;
[SerializeField, Range(0, 1)] private float CritRate = 0.1f;
		[SerializeField] private float CritMultiplier = 3f;
public int forcepower;
public int damagevalue=3;
public bool breakabled=false;
public GameObject colldebugobj;
public GameObject hitparticle;
	public bool damagehit;
 public bool oncehit=false;
 public static int totaldamage;
    // Start is called before the first frame update
    void Start()
    {hitparticle=(GameObject)Resources.Load("hiteffect");
     damagevalue+=gameObject.acessdata().power;
      }


void OnTriggerEnter(Collider other)
{
  if (other.gameObject.root()==gameObject.root())
  {
    return;
  }
colldebugobj=other.gameObject;
adddamage(other);   

 
if (other.gameObject.root().CompareTag("Explodable"))
  {
    SimpleMeshExploder.instance.Explode(other.transform);
  }  
 }


public void adddamage(Collider other){

if (other.GetComponent<Animator>()!=null)
{if (other.GetComponent<Animator>().GetBool("death"))
    return;
} 

if (breakabled)
{
    if (other.gameObject.CompareTag("Explodable")){

      SimpleMeshExploder.instance.Explode(other.gameObject.transform);
      
      }
}
      
GameObject obj=other.gameObject.transform.root.gameObject;




var crit = Random.value <= CritRate;
			var critdamagevalue = crit == true ? (int)(damagevalue * CritMultiplier) : damagevalue;
			
      

if (obj.CompareTag("Enemy")){


if (other.GetComponent<enemyhp>()!=null)
{ 
 damagehit=  other.GetComponent<enemyhp>().damage(critdamagevalue,crit,gameObject.Collider());

}else if( obj.GetComponent<enemyhp>()!=null)
{
  damagehit= obj.GetComponent<enemyhp>().damage(critdamagevalue,crit,gameObject.Collider());
}

}else if(obj.ptag())
{
  
}else
{
  if (obj.GetComponent<Rigidbody>()!=null)
  {obj.GetComponent<Rigidbody>().AddForce(transform.forward*forcepower,ForceMode.Impulse);
    
  }
}
if (damagehit)
{
  
if (forcepower!=0)
{this.addforce(other.gameObject,forcepower,transform);
    }

  damagehit=false;
}
}


    
}
