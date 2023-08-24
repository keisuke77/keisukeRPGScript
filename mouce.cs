using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.VFX;
using System.Collections;



public class mouce : MonoBehaviour
{
  
      public GameObject obj;
    public Transform transfor;
    public float x;
    public Camera cam;
  
  
    // Start is called before the first frame update
    void Start()
    {
       transfor= obj.transform;
       cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    { Vector3 vec = obj.transform.position;
  
 Vector3 Relative = transfor.InverseTransformPoint(transform.position);

Debug.Log(Input.mousePosition);
     x = Relative.x;
     Vector3 aa = cam.WorldToScreenPoint(transfor.position);
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     Debug.Log(ray);

    
}

}