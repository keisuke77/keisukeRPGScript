using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatcamera : MonoBehaviour
{
public static Camera cameraa;
    // Start is called before the first frame update
    void Start()
    {
        cameraa=keikei.camera.GetComponent<Camera>(); 
    }
public static void lookcamera(GameObject obj){

  if (cameraa!=null)
    {
         obj.transform.forward= cameraa.transform.forward;
   
    }  
}
    // Update is called once per frame
    void Update()
    {
        if (cameraa!=null)
    {
         transform.forward= cameraa.transform.forward;
   
    }
    
         }
}
