using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
  
  

void OnTriggerEnter(Collider other)
{if (other.gameObject.tag=="MainCamera"||other.gameObject.root().tag=="Player")
{
<<<<<<< HEAD
   other.gameObject.root().GetComponent<hpcore>().OnDeath();
=======
   other.root().GetComponent<playerdeath>().death();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
  
    
}else{
     Destroy(other.gameObject);   
    }
    // Update is called once per frame
  
}}
