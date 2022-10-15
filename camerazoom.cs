using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
public bool on=false;
    public Camera camera;
    public float min=50;
    public float bairitu=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void onto(){

    on=true;
}
    // Update is called once per frame
    void Update()
    {if (on)
    {
        if (camera.fieldOfView>min
 )
        {camera.fieldOfView-=bairitu;
            
            if (bairitu<1)
            {
                bairitu+=0.01f;
            }
        }
    }
           }
}
