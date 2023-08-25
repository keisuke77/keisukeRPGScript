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
<<<<<<< HEAD
    other.gameObject.cclass().anim.SetTrigger("trip");
=======
    other.gameObject.root().GetComponent<Animator>().SetTrigger("trip");
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}

    

}

    
public void ondamage(GameObject obj){
if (!obj.proottag())
{
    return;
}
    
<<<<<<< HEAD
obj.pclass().hpcore.damage(damagevalue,true,gameObject);
=======
obj.GetComponent<hpcore>().damage(damagevalue,true,gameObject);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
      if (hitdespawn)
      {
          Destroy(gameObject);
      }
        if (addforce)
{
<<<<<<< HEAD
 obj.PlayerAddForce(transform.forward*forcepower);
=======
 obj.root().GetComponent<UnityChanControlScriptWithRgidBody>().AddForce(transform.forward*forcepower);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
   
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