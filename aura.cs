using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aura : MonoBehaviour
{
    public GameObject auras;
    GameObject a;
    public bool onstart;
  
  void Start()
  {if (onstart)
  {
       aurastart(auras);

  }
     
  }
    
   public void aurastart(GameObject aurass){
       Destroy(a);
 a=Instantiate(aurass,transform.position,Quaternion.identity);
      a.transform.SetParent(transform);
  
a.SetActive(true);

   }
   
   public void aurareset(){


a.SetActive(false);

   }
   


    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
