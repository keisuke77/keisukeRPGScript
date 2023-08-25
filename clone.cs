using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("clones",2f,2f);
    }
public void clones(){

    Instantiate(gameObject,transform.position,transform.rotation);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
