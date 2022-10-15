using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoff : MonoBehaviour
{
    private bool once=false;
    public bool contrast=false;
     public Collider coll;
    public Renderer ren;
    private bool prepair=false;
    // Start is called before the first frame update
    void Start()
    {
      coll=  this.gameObject.GetComponentInChildren<Collider>();
ren=  this.gameObject.GetComponentInChildren<Renderer>();

    }


void prepar(){

prepair=true;
Invoke("off",1f);
}
void preparon(){


Invoke("on",1f);
}

void on(){
    coll.enabled=true;
    ren.enabled=true;
}
void off(){
prepair=false;
    coll.enabled=false;
    ren.enabled=false;
}
    // Update is called once per frame
    void FixedUpdate()
    {
        
if (prepair)
{bool enable=!ren.enabled;
    ren.enabled=enable;
}

        if(onoffcycle.reded){

if (once==false)
{
    if (contrast)
{
     prepar();
}else
{
    preparon();
}

once=true;
}

        }else{

if (once)
{
      if (contrast)
        {
           preparon();
        }else
        {
          prepar();  
        }
once=false;
}

      
        }
    }
}
