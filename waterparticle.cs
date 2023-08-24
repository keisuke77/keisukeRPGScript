using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterparticle : MonoBehaviour
{
    private GameObject obj;
    public GameObject intwaterparticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnTriggerEnter(Collider other)
{
   
    if (other.gameObject.tag=="water")
    {
       obj = Instantiate(intwaterparticle,transform.position,transform.rotation);
    }
   
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
