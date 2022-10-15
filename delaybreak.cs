using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delaybreak : MonoBehaviour
{
    public float delay=2;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
       if (other.tag=="block" )
    {
    StartCoroutine(falla(other.gameObject));
    }
    }
void OnCollisionEnter(Collision collisionInfo)
{
    if (collisionInfo.gameObject.tag=="block" )
    {
    
      
       StartCoroutine(falla(collisionInfo.gameObject));
    }
}
　IEnumerator falla(GameObject kine) {  
     Debug.Log("aaa");

     yield return new WaitForSeconds(delay);
 Destroy(kine);
     

 　　　 　　　// コルーチンの処理
 　　　}
    // Update is called once per frame
   
}
