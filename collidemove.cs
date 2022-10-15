using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidemove : MonoBehaviour
{
    public bool on;
    Vector3 defaultpos;
    public float value;
    [Header("何秒かけて移動するか")]
    public float movetime;
    public Vector3 movepos;
    // Start is called before the first frame update
    void Start()
    {
        defaultpos=transform.position;
    }
void OnCollisionEnter(Collision collisionInfo)
{
    if (collisionInfo.gameObject.CompareTag("Player"))
    {
        on=true;
    }
    
}
void OnCollisionExit(Collision collisionInfo)
{
    if (collisionInfo.gameObject.CompareTag("Player"))
    {
        on=false;
        
    }
    
}

    // Update is called once per frame
    void Update()
    {


        
        if (on&&!(value>1))
        {
          value+=(Time.deltaTime/movetime);
        }else if(!(0>value))
        {
             value-=(Time.deltaTime/movetime);
       
        }
if (!(value>1||0>value)){
    transform.position=Vector3.Lerp(defaultpos,defaultpos+movepos,value);
   
}

         }
}
