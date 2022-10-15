using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clearflag : MonoBehaviour
{
   public GameObject[] objs;
public UnityEvent events;

    // Start is called before the first frame update
   void Start()
   {
     
  
   }
public void clear(){

 events.Invoke();


}
    // Update is called once per frame
    void LateUpdate()
    {
       
        if (objs.Length==0)
        {
            clear();
        }
    }
}
