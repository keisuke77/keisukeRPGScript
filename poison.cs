using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
public bool enemy;
    public float often;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("damage",0.1f,often);
    }
public void damage(){
if (enemy)
{
     gameObject.transform.root.gameObject.GetComponent<enemyhp>().damage(1);
}else
{
    gameObject.transform.root.gameObject.GetComponent<hp>().damage(1);
}
   
}
   
}
