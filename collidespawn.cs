using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidespawn : MonoBehaviour
{
    public GameObject obj;

    public float respwantime;
<<<<<<< HEAD
    float time;
    public bool spawnnable;

    void Update()
    {
        if (!spawnnable)
        {
            time += Time.deltaTime;
        }

        if (time > respwantime)
        {
            spawnnable = true;
            time = 0;
        }
    }

    public void spawn()
    {
        if (spawnnable)
        {
            var a = Instantiate(obj, transform.position, Quaternion.identity);
            keikei.mobappend(a);
        }
        spawnnable = false;
    }

=======
float time;
public bool spawnnable;
    void Update()
    {
        
        if (!spawnnable)
    { time+=Time.deltaTime;
       
        
    }
       
       
       
        if (time>respwantime)
        {
            spawnnable=true;
            time=0;
        }
    }

    public void spawn(){
        if (spawnnable)
        {
            var a= Instantiate(obj,transform.position,Quaternion.identity);
            keikei.mobappend(a);
        }
        spawnnable=false;
    }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    // Start is called before the first frame update
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
<<<<<<< HEAD
    {
        spawn();
    }

=======
    {spawn();
         }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        spawn();
    }
}
