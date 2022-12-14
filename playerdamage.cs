using UnityEngine;
    
    public class playerdamage : MonoBehaviour
    {
        public bool hitdespawn;
public int damagevalue;
public bool sequencehit;
        public bool trip;
public bool addforce;
        
public float forcepower=10;
public UnityEngine.Events.UnityEvent events;



   void OnParticleCollision(GameObject other)
    {
 ondamage(other);

    }


        void OnCollisionEnter(Collision other)
    {
            ondamage(other.gameObject);
if (trip)
{
    other.gameObject.root().GetComponent<Animator>().SetTrigger("trip");
}

    

}

    
public void ondamage(GameObject obj){
if (!obj.proottag())
{
    return;
}
    
obj.GetComponent<hpcore>().damage(damagevalue,true,gameObject);
      if (hitdespawn)
      {
          Destroy(gameObject);
      }
        if (addforce)
{
 obj.PlayerAddForce(transform.forward*forcepower);
   
}
events.Invoke();
}




    void OnCollisionStay(Collision other)
    {
        if (!sequencehit)
            return;
            ondamage(other.gameObject);
}

    
    }