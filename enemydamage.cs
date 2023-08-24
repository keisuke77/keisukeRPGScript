using UnityEngine;
    
    public class enemydamage : MonoBehaviour
    {
public int damagevalue;
public bool sequencehit;
public bool addforce;
public float forcepower=10;
public bool trip;
        
        void OnCollisionEnter(Collision other)
    {GameObject obj=other.gameObject.transform.root.gameObject;
        if (obj.tag=="Enemy"){

    obj.GetComponent<enemyhp>().damage(damagevalue);
      
if (trip)
{
    other.gameObject.root().GetComponent<Animator>().SetTrigger("trip");
}

if (addforce)
{
     Rigidbody rb=obj.GetComponent<Rigidbody>();
if (rb!=null) 
{
   rb.AddForce(transform.forward*forcepower,ForceMode.Impulse); 
}
}

}


    } void OnCollisionStay(Collision other)
    {
        if (!sequencehit)
        {
            return;
        }
        if (other.gameObject.transform.root.gameObject.tag=="Enemy"){

    other.gameObject.SendMessage("damage",damagevalue);
      
}

    }
    }