using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityup : MonoBehaviour
{
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnCollisionEnter(Collision collisionInfo)
{
    if (collisionInfo.gameObject.tag=="Enemy")
    {
        collisionInfo.gameObject.GetComponent<Rigidbody>().velocity*=power;
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
