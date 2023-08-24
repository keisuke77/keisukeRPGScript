using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammercrash : MonoBehaviour
{
    public GameObject hammer;
    public GameObject crashparticle;
    public Vector3 controll;
    public int damagevalue=5; 
    public float damageradios=5;
    public SphereCollider spherecol;
    float defaultradius;

bool ondamage;
Light light;
    // Start is called before the first frame update
    void Start()
    {defaultradius=spherecol.radius;
        light=hammer.GetComponent<Light>();
light.enabled=false;
    }
public void hammerhit(){
keikei.shake();
Instantiate(crashparticle,hammer.transform.position+controll,Quaternion.identity);
ondamage=true;
light.enabled=true;
spherecol.radius=damageradios;
Invoke("end",0.2f);
}


public void end(){
    
spherecol.radius=defaultradius;
ondamage=false;
light.enabled=false;
}

 void OnTriggerEnter(Collider other)
{if (ondamage)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<enemyhp>().damage(damagevalue);
        }
    }
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
