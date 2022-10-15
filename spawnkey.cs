using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnkey : MonoBehaviour
{public Vector3 controll;
    public KeyCode aaa;
    public GameObject obj;
    public bool autospawn;
    public bool autospawnparent;
    public bool oncespawn;
    public bool oncespawnparent;
    public bool entercontroll;
    GameObject spawnpos;
    
    // Start is called before the first frame update
    void Start()
    {
        if (oncespawn)
        {
            spawnkeys();
        }if (oncespawnparent)
        {
            spawnkeysparent();
        
        }
        if (entercontroll)
        {
            spawnkeycontroll();
        }

    }

    public void spawnposset(GameObject pos)
{
spawnpos=pos;


}

public void spawnkeyspos(GameObject objs){

 Instantiate(objs,spawnpos.transform.position,Quaternion.identity);
  
}
    
    public void spawnkeysforce(GameObject objs){

        keikei.Shot(gameObject,objs,controll); 
    }
  public void spawnkeysforce(float speed,GameObject objs){

        keikei.Shot(gameObject,objs,speed,controll); 
    }
  
  
     public void spawnforward(GameObject objs){

        Instantiate(objs,transform.forward+transform.position+transform.up,transform.rotation);
  
    }  public void spawnlongforward(GameObject objs){

        Instantiate(objs,transform.forward*10+transform.position+transform.up,transform.rotation);
  
    } public void spawnmidleforward(GameObject objs){

        Instantiate(objs,transform.forward*5+transform.position+transform.up,transform.rotation);
  
    } 
     public void spawnkeys(GameObject objs){

        Instantiate(objs,transform.position,transform.rotation);
  
    } public void spawnkeysparent(GameObject objs){

       var a= Instantiate(objs,transform.position,transform.rotation);
  a.transform.SetParent(gameObject.transform);
    }public void spawnkeysparent(){

       var a= Instantiate(obj,transform.position,transform.rotation);
  a.transform.SetParent(gameObject.transform);
    }public void spawnkeycontroll(){

       var a= Instantiate(obj,transform.position+controll,transform.rotation);
  a.transform.SetParent(gameObject.transform);
    }
    public void spawnkeys(){

        Instantiate(obj,transform.position,transform.rotation);
  
    }


    
void FixedUpdate()
{
    if (Input.GetKeyDown(aaa))
    {
        spawnkeys();
         }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
