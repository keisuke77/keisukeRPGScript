using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterplane : MonoBehaviour
{public string tags="foot";
        public GameObject intwaterparticle;
        public bool orirotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnTriggerEnter(Collider other)
{
   
    if (other.CompareTag(tags))
    {
        Instantiate(intwaterparticle,other.transform.position,orirotate?Quaternion.identity:other.transform.rotation);
    }
   
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
