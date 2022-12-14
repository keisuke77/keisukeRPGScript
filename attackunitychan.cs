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
	public bool damagehit;
 public bool oncehit=false;
 public static int totaldamage;
 public float radiusDamage=10;
    // Start is called before the first frame update
    void Start()
    {
     damagevalue+=gameObject.acessdata().power;
      }


void OnTriggerStay(Collider other)
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


public void RangeAddDammage(){
var search=gameObject.RadiusSearch<Collider>(radiusDamage);
foreach (var item in search)
{
  adddamage(item);
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
			
      

if (obj.eroottag()){


if (other.GetComponent<hpcore>()!=null)
{ 
 damagehit=  other.GetComponent<hpcore>().damage(critdamagevalue,crit,gameObject.Collider(),false);

}else if( obj.GetComponent<hpcore>()!=null)
{
  damagehit= obj.GetComponent<hpcore>().damage(critdamagevalue,crit,gameObject.Collider(),false);
}

}else if(obj.proottag())
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
