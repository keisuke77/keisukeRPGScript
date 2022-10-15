using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class scalelerpgimic : MonoBehaviour
{
    public GameObject target;
    public float from;
    public float to;
    public float speed=3f;
    public GameObject cele;
      
      void OnTriggerEnter(Collider other)
      {
            if (other.gameObject.tag=="Player")
        {target.scalechange(to,speed); 
        }
      }
      void OnTriggerExit(Collider other)
      {
           if (other.gameObject.tag=="Player")
        {

           target.scalechange(from,speed);  }
 
      }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag=="Player")
        target.scalechange(to,speed); 
        }
    private void OnCollisionExit(Collision other){
        if (other.gameObject.tag=="Player")

           target.scalechange(from,speed);  
    }
    void Update()
    {
        if (target.transform.localScale.x==to)
        {keikei.deathexplosion(target,cele);
            
        }
    }
    void Start()
    {
        
    }

}
