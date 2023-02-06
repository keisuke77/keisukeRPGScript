using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
  
  

void OnTriggerEnter(Collider other)
{if (other.gameObject.tag=="MainCamera"||other.gameObject.root().tag=="Player")
{
   other.gameObject.pclass().hpcore.OnDeath();
  
    
}else{
     Destroy(other.gameObject);   
    }
    // Update is called once per frame
  
}}
