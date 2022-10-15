using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collcheck : MonoBehaviour
{

public GameObject particle;

    public string tags="breakable";
    
    public materialfade materialfade;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

void OnCollisionEnter(Collision collisionInfo)
{
    if (collisionInfo.gameObject.tag==tags)
    {
       
   breaker(collisionInfo.gameObject.transform.root.gameObject);


}
}

public void breaker(GameObject collisionInfo){

if (particle!=null)
{
    Instantiate(particle,collisionInfo.transform.position,Quaternion.identity);

}

 List<GameObject> list=getallchildren.GetAll(collisionInfo.transform.root.gameObject);
 
foreach (GameObject child in list)
{
    
        if(null == child.GetComponentInChildren<Rigidbody>())
        {
            Debug.Log(child.name);
            child.AddComponent<Rigidbody>();
              child.GetComponent<DestroyAfter>().enabled=true;


            
     }
    
    

            } 
                    }




void OnTriggerEnter(Collider collisionInfo)
{
    if (collisionInfo.gameObject.tag==tags)
    {Debug.Log("11");
       breaker(collisionInfo.gameObject);


}



}
    // Update is called once per frame
    void Update()
    {
        
    }
}
